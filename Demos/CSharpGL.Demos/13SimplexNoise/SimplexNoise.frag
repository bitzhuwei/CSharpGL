#version 150 core

in vec3 v_texCoord3D;

uniform sampler2D permTexture;
uniform sampler1D simplexTexture;
uniform sampler2D gradTexture;
uniform float time; // Used for texture animation

out vec4 out_Color;

/*
 * To create offsets of one texel and one half texel in the
 * texture lookup, we need to know the texture image size.
 */
#define ONE 0.00390625
#define ONEHALF 0.001953125
// The numbers above are 1/256 and 0.5/256, change accordingly
// if you change the code to use another texture size.

/*
 * The interpolation function. This could be a 1D texture lookup
 * to get some more speed, but it's not the main part of the algorithm.
 */
float fade(float t) {
  // return t*t*(3.0-2.0*t); // Old fade, yields discontinuous second derivative
  return t*t*t*(t*(t*6.0-15.0)+10.0); // Improved fade, yields C2-continuous noise
}


/*
 * 2D classic Perlin noise. Fast, but less useful than 3D noise.
 */
float noise(vec2 P)
{
  vec2 Pi = ONE*floor(P)+ONEHALF; // Integer part, scaled and offset for texture lookup
  vec2 Pf = fract(P);             // Fractional part for interpolation

  // Noise contribution from lower left corner
  vec2 grad00 = texture2D(permTexture, Pi).rg * 4.0 - 1.0;
  float n00 = dot(grad00, Pf);

  // Noise contribution from lower right corner
  vec2 grad10 = texture2D(permTexture, Pi + vec2(ONE, 0.0)).rg * 4.0 - 1.0;
  float n10 = dot(grad10, Pf - vec2(1.0, 0.0));

  // Noise contribution from upper left corner
  vec2 grad01 = texture2D(permTexture, Pi + vec2(0.0, ONE)).rg * 4.0 - 1.0;
  float n01 = dot(grad01, Pf - vec2(0.0, 1.0));

  // Noise contribution from upper right corner
  vec2 grad11 = texture2D(permTexture, Pi + vec2(ONE, ONE)).rg * 4.0 - 1.0;
  float n11 = dot(grad11, Pf - vec2(1.0, 1.0));

  // Blend contributions along x
  vec2 n_x = mix(vec2(n00, n01), vec2(n10, n11), fade(Pf.x));

  // Blend contributions along y
  float n_xy = mix(n_x.x, n_x.y, fade(Pf.y));

  // We're done, return the final noise value.
  return n_xy;
}


/*
 * 3D classic noise. Slower, but a lot more useful than 2D noise.
 */
float noise(vec3 P)
{
  vec3 Pi = ONE*floor(P)+ONEHALF; // Integer part, scaled so +1 moves one texel
                                  // and offset 1/2 texel to sample texel centers
  vec3 Pf = fract(P);     // Fractional part for interpolation

  // Noise contributions from (x=0, y=0), z=0 and z=1
  float perm00 = texture2D(permTexture, Pi.xy).a ;
  vec3  grad000 = texture2D(permTexture, vec2(perm00, Pi.z)).rgb * 4.0 - 1.0;
  float n000 = dot(grad000, Pf);
  vec3  grad001 = texture2D(permTexture, vec2(perm00, Pi.z + ONE)).rgb * 4.0 - 1.0;
  float n001 = dot(grad001, Pf - vec3(0.0, 0.0, 1.0));

  // Noise contributions from (x=0, y=1), z=0 and z=1
  float perm01 = texture2D(permTexture, Pi.xy + vec2(0.0, ONE)).a ;
  vec3  grad010 = texture2D(permTexture, vec2(perm01, Pi.z)).rgb * 4.0 - 1.0;
  float n010 = dot(grad010, Pf - vec3(0.0, 1.0, 0.0));
  vec3  grad011 = texture2D(permTexture, vec2(perm01, Pi.z + ONE)).rgb * 4.0 - 1.0;
  float n011 = dot(grad011, Pf - vec3(0.0, 1.0, 1.0));

  // Noise contributions from (x=1, y=0), z=0 and z=1
  float perm10 = texture2D(permTexture, Pi.xy + vec2(ONE, 0.0)).a ;
  vec3  grad100 = texture2D(permTexture, vec2(perm10, Pi.z)).rgb * 4.0 - 1.0;
  float n100 = dot(grad100, Pf - vec3(1.0, 0.0, 0.0));
  vec3  grad101 = texture2D(permTexture, vec2(perm10, Pi.z + ONE)).rgb * 4.0 - 1.0;
  float n101 = dot(grad101, Pf - vec3(1.0, 0.0, 1.0));

  // Noise contributions from (x=1, y=1), z=0 and z=1
  float perm11 = texture2D(permTexture, Pi.xy + vec2(ONE, ONE)).a ;
  vec3  grad110 = texture2D(permTexture, vec2(perm11, Pi.z)).rgb * 4.0 - 1.0;
  float n110 = dot(grad110, Pf - vec3(1.0, 1.0, 0.0));
  vec3  grad111 = texture2D(permTexture, vec2(perm11, Pi.z + ONE)).rgb * 4.0 - 1.0;
  float n111 = dot(grad111, Pf - vec3(1.0, 1.0, 1.0));

  // Blend contributions along x
  vec4 n_x = mix(vec4(n000, n001, n010, n011),
                 vec4(n100, n101, n110, n111), fade(Pf.x));

  // Blend contributions along y
  vec2 n_xy = mix(n_x.xy, n_x.zw, fade(Pf.y));

  // Blend contributions along z
  float n_xyz = mix(n_xy.x, n_xy.y, fade(Pf.z));

  // We're done, return the final noise value.
  return n_xyz;
}


/*
 * 4D classic noise. Slow, but very useful. 4D simplex noise is a lot faster.
 *
 * This function performs 8 texture lookups and 16 dependent texture lookups,
 * 16 dot products, 4 mix operations and a lot of additions and multiplications.
 * Needless to say, it's not super fast. But it's not dead slow either.
 */
float noise(vec4 P)
{
  vec4 Pi = ONE*floor(P)+ONEHALF; // Integer part, scaled so +1 moves one texel
                                  // and offset 1/2 texel to sample texel centers
  vec4 Pf = fract(P);      // Fractional part for interpolation

  // "n0000" is the noise contribution from (x=0, y=0, z=0, w=0), and so on
  float perm00xy = texture2D(permTexture, Pi.xy).a ;
  float perm00zw = texture2D(permTexture, Pi.zw).a ;
  vec4 grad0000 = texture2D(gradTexture, vec2(perm00xy, perm00zw)).rgba * 4.0 -1.0;
  float n0000 = dot(grad0000, Pf);

  float perm01zw = texture2D(permTexture, Pi.zw  + vec2(0.0, ONE)).a ;
  vec4  grad0001 = texture2D(gradTexture, vec2(perm00xy, perm01zw)).rgba * 4.0 - 1.0;
  float n0001 = dot(grad0001, Pf - vec4(0.0, 0.0, 0.0, 1.0));

  float perm10zw = texture2D(permTexture, Pi.zw  + vec2(ONE, 0.0)).a ;
  vec4  grad0010 = texture2D(gradTexture, vec2(perm00xy, perm10zw)).rgba * 4.0 - 1.0;
  float n0010 = dot(grad0010, Pf - vec4(0.0, 0.0, 1.0, 0.0));

  float perm11zw = texture2D(permTexture, Pi.zw  + vec2(ONE, ONE)).a ;
  vec4  grad0011 = texture2D(gradTexture, vec2(perm00xy, perm11zw)).rgba * 4.0 - 1.0;
  float n0011 = dot(grad0011, Pf - vec4(0.0, 0.0, 1.0, 1.0));

  float perm01xy = texture2D(permTexture, Pi.xy + vec2(0.0, ONE)).a ;
  vec4  grad0100 = texture2D(gradTexture, vec2(perm01xy, perm00zw)).rgba * 4.0 - 1.0;
  float n0100 = dot(grad0100, Pf - vec4(0.0, 1.0, 0.0, 0.0));

  vec4  grad0101 = texture2D(gradTexture, vec2(perm01xy, perm01zw)).rgba * 4.0 - 1.0;
  float n0101 = dot(grad0101, Pf - vec4(0.0, 1.0, 0.0, 1.0));

  vec4  grad0110 = texture2D(gradTexture, vec2(perm01xy, perm10zw)).rgba * 4.0 - 1.0;
  float n0110 = dot(grad0110, Pf - vec4(0.0, 1.0, 1.0, 0.0));

  vec4  grad0111 = texture2D(gradTexture, vec2(perm01xy, perm11zw)).rgba * 4.0 - 1.0;
  float n0111 = dot(grad0111, Pf - vec4(0.0, 1.0, 1.0, 1.0));

  float perm10xy = texture2D(permTexture, Pi.xy + vec2(ONE, 0.0)).a ;
  vec4  grad1000 = texture2D(gradTexture, vec2(perm10xy, perm00zw)).rgba * 4.0 - 1.0;
  float n1000 = dot(grad1000, Pf - vec4(1.0, 0.0, 0.0, 0.0));

  vec4  grad1001 = texture2D(gradTexture, vec2(perm10xy, perm01zw)).rgba * 4.0 - 1.0;
  float n1001 = dot(grad1001, Pf - vec4(1.0, 0.0, 0.0, 1.0));

  vec4  grad1010 = texture2D(gradTexture, vec2(perm10xy, perm10zw)).rgba * 4.0 - 1.0;
  float n1010 = dot(grad1010, Pf - vec4(1.0, 0.0, 1.0, 0.0));

  vec4  grad1011 = texture2D(gradTexture, vec2(perm10xy, perm11zw)).rgba * 4.0 - 1.0;
  float n1011 = dot(grad1011, Pf - vec4(1.0, 0.0, 1.0, 1.0));

  float perm11xy = texture2D(permTexture, Pi.xy + vec2(ONE, ONE)).a ;
  vec4  grad1100 = texture2D(gradTexture, vec2(perm11xy, perm00zw)).rgba * 4.0 - 1.0;
  float n1100 = dot(grad1100, Pf - vec4(1.0, 1.0, 0.0, 0.0));

  vec4  grad1101 = texture2D(gradTexture, vec2(perm11xy, perm01zw)).rgba * 4.0 - 1.0;
  float n1101 = dot(grad1101, Pf - vec4(1.0, 1.0, 0.0, 1.0));

  vec4  grad1110 = texture2D(gradTexture, vec2(perm11xy, perm10zw)).rgba * 4.0 - 1.0;
  float n1110 = dot(grad1110, Pf - vec4(1.0, 1.0, 1.0, 0.0));

  vec4  grad1111 = texture2D(gradTexture, vec2(perm11xy, perm11zw)).rgba * 4.0 - 1.0;
  float n1111 = dot(grad1111, Pf - vec4(1.0, 1.0, 1.0, 1.0));

  // Blend contributions along x
  float fadex = fade(Pf.x);
  vec4 n_x0 = mix(vec4(n0000, n0001, n0010, n0011),
                  vec4(n1000, n1001, n1010, n1011), fadex);
  vec4 n_x1 = mix(vec4(n0100, n0101, n0110, n0111),
                  vec4(n1100, n1101, n1110, n1111), fadex);

  // Blend contributions along y
  vec4 n_xy = mix(n_x0, n_x1, fade(Pf.y));

  // Blend contributions along z
  vec2 n_xyz = mix(n_xy.xy, n_xy.zw, fade(Pf.z));

  // Blend contributions along w
  float n_xyzw = mix(n_xyz.x, n_xyz.y, fade(Pf.w));

  // We're done, return the final noise value.
  return n_xyzw;
}


/*
 * 2D simplex noise. Somewhat slower but much better looking than classic noise.
 */
float snoise(vec2 P) {

// Skew and unskew factors are a bit hairy for 2D, so define them as constants
// This is (sqrt(3.0)-1.0)/2.0
#define F2 0.366025403784
// This is (3.0-sqrt(3.0))/6.0
#define G2 0.211324865405

  // Skew the (x,y) space to determine which cell of 2 simplices we're in
 	float s = (P.x + P.y) * F2;   // Hairy factor for 2D skewing
  vec2 Pi = floor(P + s);
  float t = (Pi.x + Pi.y) * G2; // Hairy factor for unskewing
  vec2 P0 = Pi - t; // Unskew the cell origin back to (x,y) space
  Pi = Pi * ONE + ONEHALF; // Integer part, scaled and offset for texture lookup

  vec2 Pf0 = P - P0;  // The x,y distances from the cell origin

  // For the 2D case, the simplex shape is an equilateral triangle.
  // Find out whether we are above or below the x=y diagonal to
  // determine which of the two triangles we're in.
  vec2 o1;
  if(Pf0.x > Pf0.y) o1 = vec2(1.0, 0.0);  // +x, +y traversal order
  else o1 = vec2(0.0, 1.0);               // +y, +x traversal order

  // Noise contribution from simplex origin
  vec2 grad0 = texture2D(permTexture, Pi).rg * 4.0 - 1.0;
  float t0 = 0.5 - dot(Pf0, Pf0);
  float n0;
  if (t0 < 0.0) n0 = 0.0;
  else {
    t0 *= t0;
    n0 = t0 * t0 * dot(grad0, Pf0);
  }

  // Noise contribution from middle corner
  vec2 Pf1 = Pf0 - o1 + G2;
  vec2 grad1 = texture2D(permTexture, Pi + o1*ONE).rg * 4.0 - 1.0;
  float t1 = 0.5 - dot(Pf1, Pf1);
  float n1;
  if (t1 < 0.0) n1 = 0.0;
  else {
    t1 *= t1;
    n1 = t1 * t1 * dot(grad1, Pf1);
  }
  
  // Noise contribution from last corner
  vec2 Pf2 = Pf0 - vec2(1.0-2.0*G2);
  vec2 grad2 = texture2D(permTexture, Pi + vec2(ONE, ONE)).rg * 4.0 - 1.0;
  float t2 = 0.5 - dot(Pf2, Pf2);
  float n2;
  if(t2 < 0.0) n2 = 0.0;
  else {
    t2 *= t2;
    n2 = t2 * t2 * dot(grad2, Pf2);
  }

  // Sum up and scale the result to cover the range [-1,1]
  return 70.0 * (n0 + n1 + n2);
}


/*
 * 3D simplex noise. Comparable in speed to classic noise, better looking.
 */
float snoise(vec3 P) {

// The skewing and unskewing factors are much simpler for the 3D case
#define F3 0.333333333333
#define G3 0.166666666667

  // Skew the (x,y,z) space to determine which cell of 6 simplices we're in
 	float s = (P.x + P.y + P.z) * F3; // Factor for 3D skewing
  vec3 Pi = floor(P + s);
  float t = (Pi.x + Pi.y + Pi.z) * G3;
  vec3 P0 = Pi - t; // Unskew the cell origin back to (x,y,z) space
  Pi = Pi * ONE + ONEHALF; // Integer part, scaled and offset for texture lookup

  vec3 Pf0 = P - P0;  // The x,y distances from the cell origin

  // For the 3D case, the simplex shape is a slightly irregular tetrahedron.
  // To find out which of the six possible tetrahedra we're in, we need to
  // determine the magnitude ordering of x, y and z components of Pf0.
  // The method below is explained briefly in the C code. It uses a small
  // 1D texture as a lookup table. The table is designed to work for both
  // 3D and 4D noise, so only 8 (only 6, actually) of the 64 indices are
  // used here.
  float c1 = (Pf0.x > Pf0.y) ? 0.5078125 : 0.0078125; // 1/2 + 1/128
  float c2 = (Pf0.x > Pf0.z) ? 0.25 : 0.0;
  float c3 = (Pf0.y > Pf0.z) ? 0.125 : 0.0;
  float sindex = c1 + c2 + c3;
  vec3 offsets = texture1D(simplexTexture, sindex).rgb;
  vec3 o1 = step(0.375, offsets);
  vec3 o2 = step(0.125, offsets);

  // Noise contribution from simplex origin
  float perm0 = texture2D(permTexture, Pi.xy).a;
  vec3  grad0 = texture2D(permTexture, vec2(perm0, Pi.z)).rgb * 4.0 - 1.0;
  float t0 = 0.6 - dot(Pf0, Pf0);
  float n0;
  if (t0 < 0.0) n0 = 0.0;
  else {
    t0 *= t0;
    n0 = t0 * t0 * dot(grad0, Pf0);
  }

  // Noise contribution from second corner
  vec3 Pf1 = Pf0 - o1 + G3;
  float perm1 = texture2D(permTexture, Pi.xy + o1.xy*ONE).a;
  vec3  grad1 = texture2D(permTexture, vec2(perm1, Pi.z + o1.z*ONE)).rgb * 4.0 - 1.0;
  float t1 = 0.6 - dot(Pf1, Pf1);
  float n1;
  if (t1 < 0.0) n1 = 0.0;
  else {
    t1 *= t1;
    n1 = t1 * t1 * dot(grad1, Pf1);
  }
  
  // Noise contribution from third corner
  vec3 Pf2 = Pf0 - o2 + 2.0 * G3;
  float perm2 = texture2D(permTexture, Pi.xy + o2.xy*ONE).a;
  vec3  grad2 = texture2D(permTexture, vec2(perm2, Pi.z + o2.z*ONE)).rgb * 4.0 - 1.0;
  float t2 = 0.6 - dot(Pf2, Pf2);
  float n2;
  if (t2 < 0.0) n2 = 0.0;
  else {
    t2 *= t2;
    n2 = t2 * t2 * dot(grad2, Pf2);
  }
  
  // Noise contribution from last corner
  vec3 Pf3 = Pf0 - vec3(1.0-3.0*G3);
  float perm3 = texture2D(permTexture, Pi.xy + vec2(ONE, ONE)).a;
  vec3  grad3 = texture2D(permTexture, vec2(perm3, Pi.z + ONE)).rgb * 4.0 - 1.0;
  float t3 = 0.6 - dot(Pf3, Pf3);
  float n3;
  if(t3 < 0.0) n3 = 0.0;
  else {
    t3 *= t3;
    n3 = t3 * t3 * dot(grad3, Pf3);
  }

  // Sum up and scale the result to cover the range [-1,1]
  return 32.0 * (n0 + n1 + n2 + n3);
}


/*
 * 4D simplex noise. A lot faster than classic 4D noise, and better looking.
 */

float snoise(vec4 P) {

// The skewing and unskewing factors are hairy again for the 4D case
// This is (sqrt(5.0)-1.0)/4.0
#define F4 0.309016994375
// This is (5.0-sqrt(5.0))/20.0
#define G4 0.138196601125

  // Skew the (x,y,z,w) space to determine which cell of 24 simplices we're in
 	float s = (P.x + P.y + P.z + P.w) * F4; // Factor for 4D skewing
  vec4 Pi = floor(P + s);
  float t = (Pi.x + Pi.y + Pi.z + Pi.w) * G4;
  vec4 P0 = Pi - t; // Unskew the cell origin back to (x,y,z,w) space
  Pi = Pi * ONE + ONEHALF; // Integer part, scaled and offset for texture lookup

  vec4 Pf0 = P - P0;  // The x,y distances from the cell origin

  // For the 4D case, the simplex is a 4D shape I won't even try to describe.
  // To find out which of the 24 possible simplices we're in, we need to
  // determine the magnitude ordering of x, y, z and w components of Pf0.
  // The method below is presented without explanation. It uses a small 1D
  // texture as a lookup table. The table is designed to work for both
  // 3D and 4D noise and contains 64 indices, of which only 24 are actually
  // used. An extension to 5D would require a larger texture here.
  float c1 = (Pf0.x > Pf0.y) ? 0.5078125 : 0.0078125; // 1/2 + 1/128
  float c2 = (Pf0.x > Pf0.z) ? 0.25 : 0.0;
  float c3 = (Pf0.y > Pf0.z) ? 0.125 : 0.0;
  float c4 = (Pf0.x > Pf0.w) ? 0.0625 : 0.0;
  float c5 = (Pf0.y > Pf0.w) ? 0.03125 : 0.0;
  float c6 = (Pf0.z > Pf0.w) ? 0.015625 : 0.0;
  float sindex = c1 + c2 + c3 + c4 + c5 + c6;
  vec4 offsets = texture1D(simplexTexture, sindex).rgba;
  vec4 o1 = step(0.625, offsets);
  vec4 o2 = step(0.375, offsets);
  vec4 o3 = step(0.125, offsets);

  // Noise contribution from simplex origin
  float perm0xy = texture2D(permTexture, Pi.xy).a;
  float perm0zw = texture2D(permTexture, Pi.zw).a;
  vec4  grad0 = texture2D(gradTexture, vec2(perm0xy, perm0zw)).rgba * 4.0 - 1.0;
  float t0 = 0.6 - dot(Pf0, Pf0);
  float n0;
  if (t0 < 0.0) n0 = 0.0;
  else {
    t0 *= t0;
    n0 = t0 * t0 * dot(grad0, Pf0);
  }

  // Noise contribution from second corner
  vec4 Pf1 = Pf0 - o1 + G4;
  o1 = o1 * ONE;
  float perm1xy = texture2D(permTexture, Pi.xy + o1.xy).a;
  float perm1zw = texture2D(permTexture, Pi.zw + o1.zw).a;
  vec4  grad1 = texture2D(gradTexture, vec2(perm1xy, perm1zw)).rgba * 4.0 - 1.0;
  float t1 = 0.6 - dot(Pf1, Pf1);
  float n1;
  if (t1 < 0.0) n1 = 0.0;
  else {
    t1 *= t1;
    n1 = t1 * t1 * dot(grad1, Pf1);
  }
  
  // Noise contribution from third corner
  vec4 Pf2 = Pf0 - o2 + 2.0 * G4;
  o2 = o2 * ONE;
  float perm2xy = texture2D(permTexture, Pi.xy + o2.xy).a;
  float perm2zw = texture2D(permTexture, Pi.zw + o2.zw).a;
  vec4  grad2 = texture2D(gradTexture, vec2(perm2xy, perm2zw)).rgba * 4.0 - 1.0;
  float t2 = 0.6 - dot(Pf2, Pf2);
  float n2;
  if (t2 < 0.0) n2 = 0.0;
  else {
    t2 *= t2;
    n2 = t2 * t2 * dot(grad2, Pf2);
  }
  
  // Noise contribution from fourth corner
  vec4 Pf3 = Pf0 - o3 + 3.0 * G4;
  o3 = o3 * ONE;
  float perm3xy = texture2D(permTexture, Pi.xy + o3.xy).a;
  float perm3zw = texture2D(permTexture, Pi.zw + o3.zw).a;
  vec4  grad3 = texture2D(gradTexture, vec2(perm3xy, perm3zw)).rgba * 4.0 - 1.0;
  float t3 = 0.6 - dot(Pf3, Pf3);
  float n3;
  if (t3 < 0.0) n3 = 0.0;
  else {
    t3 *= t3;
    n3 = t3 * t3 * dot(grad3, Pf3);
  }
  
  // Noise contribution from last corner
  vec4 Pf4 = Pf0 - vec4(1.0-4.0*G4);
  float perm4xy = texture2D(permTexture, Pi.xy + vec2(ONE, ONE)).a;
  float perm4zw = texture2D(permTexture, Pi.zw + vec2(ONE, ONE)).a;
  vec4  grad4 = texture2D(gradTexture, vec2(perm4xy, perm4zw)).rgba * 4.0 - 1.0;
  float t4 = 0.6 - dot(Pf4, Pf4);
  float n4;
  if(t4 < 0.0) n4 = 0.0;
  else {
    t4 *= t4;
    n4 = t4 * t4 * dot(grad4, Pf4);
  }

  // Sum up and scale the result to cover the range [-1,1]
  return 27.0 * (n0 + n1 + n2 + n3 + n4);
}

void main(void)
{
  /* These lines test, in order, 2D classic noise, 2D simplex noise,
   * 3D classic noise, 3D simplex noise, 4D classic noise, and finally
   * 4D simplex noise.
   * Everything but the 4D simpex noise will make some uniform
   * variables remain unused and be optimized away by the compiler,
   * so OpenGL will fail to bind them. It's safe to ignore these
   * warnings from the C program. The program is designed to work anyway.
   */
  //float n = noise(v_texCoord2D * 32.0 + 240.0);
  //float n = snoise(v_texCoord2D * 16.0);
  //float n = noise(vec3(4.0 * v_texCoord3D.xyz * (2.0 + sin(0.5 * time))));
  //float n = snoise(vec3(2.0 * v_texCoord3D.xyz * (2.0 + sin(0.5 * time))));
  //float n = noise(vec4(8.0 * v_texCoord3D.xyz, 0.5 * time));
  float n = snoise(vec4(5.0 * v_texCoord3D.xyz, 0.5 * time));

  n = n * 0.25 + 0.75;
  out_Color = vec4(n, n, n, 1.0);
}
