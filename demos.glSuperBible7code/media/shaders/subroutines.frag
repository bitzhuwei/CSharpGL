#version 420 core

// First, declare the subroutine type
subroutine vec4 sub_mySubroutine(vec4 param1);

// Next declare a coule of functions that can be used as subroutine...
subroutine (sub_mySubroutine)
vec4 myFunction1(vec4 param1)
{
    return param1 * vec4(1.0, 0.25, 0.25, 1.0);
}

subroutine (sub_mySubroutine)
vec4 myFunction2(vec4 param1)
{
    return param1 * vec4(0.25, 0.25, 1.0, 1.0);
}

// Finally, declare a subroutine uniform that can be 'pointed'
// at subroutine functions matching its signature
subroutine uniform sub_mySubroutine mySubroutineUniform;

// Output color
out vec4 color;

void main(void)
{
    // Call subroutine through uniform
    color = mySubroutineUniform(vec4(1.0));
}
