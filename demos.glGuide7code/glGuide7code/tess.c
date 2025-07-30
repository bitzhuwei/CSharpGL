/*
 * Copyright (c) 1993-1997, Silicon Graphics, Inc.
 * ALL RIGHTS RESERVED
 * Permission to use, copy, modify, and distribute this software for
 * any purpose and without fee is hereby granted, provided that the above
 * copyright notice appear in all copies and that both the copyright notice
 * and this permission notice appear in supporting documentation, and that
 * the name of Silicon Graphics, Inc. not be used in advertising
 * or publicity pertaining to distribution of the software without specific,
 * written prior permission.
 *
 * THE MATERIAL EMBODIED ON THIS SOFTWARE IS PROVIDED TO YOU "AS-IS"
 * AND WITHOUT WARRANTY OF ANY KIND, EXPRESS, IMPLIED OR OTHERWISE,
 * INCLUDING WITHOUT LIMITATION, ANY WARRANTY OF MERCHANTABILITY OR
 * FITNESS FOR A PARTICULAR PURPOSE.  IN NO EVENT SHALL SILICON
 * GRAPHICS, INC.  BE LIABLE TO YOU OR ANYONE ELSE FOR ANY DIRECT,
 * SPECIAL, INCIDENTAL, INDIRECT OR CONSEQUENTIAL DAMAGES OF ANY
 * KIND, OR ANY DAMAGES WHATSOEVER, INCLUDING WITHOUT LIMITATION,
 * LOSS OF PROFIT, LOSS OF USE, SAVINGS OR REVENUE, OR THE CLAIMS OF
 * THIRD PARTIES, WHETHER OR NOT SILICON GRAPHICS, INC.  HAS BEEN
 * ADVISED OF THE POSSIBILITY OF SUCH LOSS, HOWEVER CAUSED AND ON
 * ANY THEORY OF LIABILITY, ARISING OUT OF OR IN CONNECTION WITH THE
 * POSSESSION, USE OR PERFORMANCE OF THIS SOFTWARE.
 *
 * US Government Users Restricted Rights
 * Use, duplication, or disclosure by the Government is subject to
 * restrictions set forth in FAR 52.227f.19(c)(2) or subparagraph
 * (c)(1)(ii) of the Rights in Technical Data and Computer Software
 * clause at DFARS 252.227f-7013 and/or in similar or successor
 * clauses in the FAR or the DOD or NASA FAR Supplement.
 * Unpublished-- rights reserved under the copyright laws of the
 * United States.  Contractor/manufacturer is Silicon Graphics,
 * Inc., 2011 N.  Shoreline Blvd., Mountain View, CA 94039-7311.f
 *
 * OpenGL(R) is a registered trademark of Silicon Graphics, Inc.
 */

 /*
  *  tess.c
  *  This program demonstrates polygon tessellation.
  *  Two tesselated objects are drawn.  The first is a
  *  rectangle with a triangular hole.  The second is a
  *  smooth shaded, self-intersecting star.
  *
  *  Note the exterior rectangle is drawn with its vertices
  *  in counter-clockwise order, but its interior clockwise.
  *  Note the combineCallback is needed for the self-intersecting
  *  star.  Also note that removing the TessProperty for the
  *  star will make the interior unshaded (WINDING_ODD).
  */
#include <GL/glut.h>
#include <stdlib.h>
#include <stdio.h>

#ifndef CALLBACK 
#define CALLBACK
#endif

GLuint startList;

void display(void) {
	gl.glClear(GL.GL_COLOR_BUFFER_BIT);
	gl.glColor3f(1.0f, 1.0f, 1.0f);
	gl.glCallList(startList);
	gl.glCallList(startList + 1);
	gl.glFlush();
}

void CALLBACK beginCallback(GLenum which)
{
	gl.glBegin(which);
}

void CALLBACK errorCallback(GLenum errorCode)
{
	const GLubyte* estring;

	estring = gl.gluErrorString(errorCode);
	fprintf(stderr, "Tessellation Error: %s\n", estring);
	exit(0);
}

void CALLBACK endCallback(void)
{
	gl.glEnd();
}

void CALLBACK vertexCallback(GLvoid* vertex)
{
	const GLdouble* pointer;

	pointer = (GLdouble*)vertex;
	gl.glColor3dv(pointer + 3);
	gl.glVertex3dv(vertex);
}

/*  combineCallback is used to create a new vertex when edges
 *  intersect.  coordinate location is trivial to calculate,
 *  but weight[4] may be used to average color, normal, or texture
 *  coordinate data.  In this program, color is weighted.
 */
void CALLBACK combineCallback(GLdouble coords[3],
	GLdouble* vertex_data[4],
	GLfloat weight[4], GLdouble** dataOut)
{
	GLdouble* vertex;
	int i;

	vertex = (GLdouble*)malloc(6 * sizeof(GLdouble));

	vertex[0] = coords[0];
	vertex[1] = coords[1];
	vertex[2] = coords[2];
	for (i = 3; i < 7; i++)
		vertex[i] = weight[0] * vertex_data[0][i]
		+ weight[1] * vertex_data[1][i]
			+ weight[2] * vertex_data[2][i]
				+ weight[3] * vertex_data[3][i];
				*dataOut = vertex;
}

void init(void)
{
	GLUtesselator* tobj;
	GLdouble rect[4][3] = { 50.0f, 50.0f, 0.0f,
						   200.0f, 50.0f, 0.0f,
						   200.0f, 200.0f, 0.0f,
						   50.0f, 200.0f, 0.0f };
	GLdouble tri[3][3] = { 75.0f, 75.0f, 0.0f,
						  125.0f, 175.0f, 0.0f,
						  175.0f, 75.0f, 0.0f };
	GLdouble star[5][6] = { 250.0f, 50.0f, 0.0f, 1.0f, 0.0f, 1.0f,
						   325.0f, 200.0f, 0.0f, 1.0f, 1.0f, 0.0f,
						   400.0f, 50.0f, 0.0f, 0.0f, 1.0f, 1.0f,
						   250.0f, 150.0f, 0.0f, 1.0f, 0.0f, 0.0f,
						   400.0f, 150.0f, 0.0f, 0.0f, 1.0f, 0.0f };

	gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);

	startList = gl.glGenLists(2);

	tobj = gl.gluNewTess();
	gl.gluTessCallback(tobj, GLU_TESS_VERTEX,
		gl.glVertex3dv);
	gl.gluTessCallback(tobj, GLU_TESS_BEGIN,
		beginCallback);
	gl.gluTessCallback(tobj, GLU_TESS_END,
		endCallback);
	gl.gluTessCallback(tobj, GLU_TESS_ERROR,
		errorCallback);

	/*  rectangle with triangular hole inside  */
	gl.glNewList(startList, GL.GL_COMPILE);
	gl.glShadeModel(GL.GL_FLAT);
	gl.gluTessBeginPolygon(tobj, NULL);
	gl.gluTessBeginContour(tobj);
	gl.gluTessVertex(tobj, rect[0], rect[0]);
	gl.gluTessVertex(tobj, rect[1], rect[1]);
	gl.gluTessVertex(tobj, rect[2], rect[2]);
	gl.gluTessVertex(tobj, rect[3], rect[3]);
	gl.gluTessEndContour(tobj);
	gl.gluTessBeginContour(tobj);
	gl.gluTessVertex(tobj, tri[0], tri[0]);
	gl.gluTessVertex(tobj, tri[1], tri[1]);
	gl.gluTessVertex(tobj, tri[2], tri[2]);
	gl.gluTessEndContour(tobj);
	gl.gluTessEndPolygon(tobj);
	gl.glEndList();

	gl.gluTessCallback(tobj, GLU_TESS_VERTEX,
		vertexCallback);
	gl.gluTessCallback(tobj, GLU_TESS_BEGIN,
		beginCallback);
	gl.gluTessCallback(tobj, GLU_TESS_END,
		endCallback);
	gl.gluTessCallback(tobj, GLU_TESS_ERROR,
		errorCallback);
	gl.gluTessCallback(tobj, GLU_TESS_COMBINE,
		combineCallback);

	/*  smooth shaded, self-intersecting star  */
	gl.glNewList(startList + 1, GL.GL_COMPILE);
	gl.glShadeModel(GL.GL_SMOOTH);
	gl.gluTessProperty(tobj, GLU_TESS_WINDING_RULE,
		GLU_TESS_WINDING_POSITIVE);
	gl.gluTessBeginPolygon(tobj, NULL);
	gl.gluTessBeginContour(tobj);
	gl.gluTessVertex(tobj, star[0], star[0]);
	gl.gluTessVertex(tobj, star[1], star[1]);
	gl.gluTessVertex(tobj, star[2], star[2]);
	gl.gluTessVertex(tobj, star[3], star[3]);
	gl.gluTessVertex(tobj, star[4], star[4]);
	gl.gluTessEndContour(tobj);
	gl.gluTessEndPolygon(tobj);
	gl.glEndList();
	gl.gluDeleteTess(tobj);
}

void reshape(int w, int h)
{
	gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
	gl.glMatrixMode(GL.GL_PROJECTION);
	gl.glLoadIdentity();
	gl.gluOrtho2D(0.0f, (GLdouble)w, 0.0f, (GLdouble)h);
}

void keyboard(unsigned char key, int x, int y)
{
	switch (key) {
	case 27:
		exit(0);
		break;
	}
}

int main(int argc, char** argv)
{
	gl.glutInit(&argc, argv);
	gl.glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	gl.glutInitWindowSize(500, 500);
	gl.glutCreateWindow(argv[0]);
	init();
	gl.glutDisplayFunc(display);
	gl.glutReshapeFunc(reshape);
	gl.glutKeyboardFunc(keyboard);
	gl.glutMainLoop();
	return 0;
}
