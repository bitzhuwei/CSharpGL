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
  *  tesswind.c
  *  This program demonstrates the winding rule polygon
  *  tessellation property.  Four tessellated objects are drawn,
  *  each with very different contours.  When the w key is pressed,
  *  the objects are drawn with a different winding rule.
  */
#include <GL/glut.h>
#include <stdlib.h>
#include <stdio.h>

#ifndef CALLBACK
#define CALLBACK
#endif

GLdouble currentWinding = GLU_TESS_WINDING_ODD;
int currentShape = 0;
GLUtesselator* tobj;
GLuint list;

/*  Make four display lists,
 *  each with a different tessellated object.
 */
void makeNewLists(void) {
	int i;
	static GLdouble rects[12][3] =
	{ 50.0f, 50.0f, 0.0f, 300.0f, 50.0f, 0.0f,
	 300.0f, 300.0f, 0.0f, 50.0f, 300.0f, 0.0f,
	 100.0f, 100.0f, 0.0f, 250.0f, 100.0f, 0.0f,
	 250.0f, 250.0f, 0.0f, 100.0f, 250.0f, 0.0f,
	 150.0f, 150.0f, 0.0f, 200.0f, 150.0f, 0.0f,
	 200.0f, 200.0f, 0.0f, 150.0f, 200.0f, 0.0f };
	static GLdouble spiral[16][3] =
	{ 400.0f, 250.0f, 0.0f, 400.0f, 50.0f, 0.0f,
	 50.0f, 50.0f, 0.0f, 50.0f, 400.0f, 0.0f,
	 350.0f, 400.0f, 0.0f, 350.0f, 100.0f, 0.0f,
	 100.0f, 100.0f, 0.0f, 100.0f, 350.0f, 0.0f,
	 300.0f, 350.0f, 0.0f, 300.0f, 150.0f, 0.0f,
	 150.0f, 150.0f, 0.0f, 150.0f, 300.0f, 0.0f,
	 250.0f, 300.0f, 0.0f, 250.0f, 200.0f, 0.0f,
	 200.0f, 200.0f, 0.0f, 200.0f, 250.0f, 0.0f };
	static GLdouble quad1[4][3] =
	{ 50.0f, 150.0f, 0.0f, 350.0f, 150.0f, 0.0f,
	350.0f, 200.0f, 0.0f, 50.0f, 200.0f, 0.0f };
	static GLdouble quad2[4][3] =
	{ 100.0f, 100.0f, 0.0f, 300.0f, 100.0f, 0.0f,
	 300.0f, 350.0f, 0.0f, 100.0f, 350.0f, 0.0f };
	static GLdouble tri[3][3] =
	{ 200.0f, 50.0f, 0.0f, 250.0f, 300.0f, 0.0f,
	 150.0f, 300.0f, 0.0f };

	gl.gluTessProperty(tobj, GLU_TESS_WINDING_RULE,
		currentWinding);

	gl.glNewList(list, GL.GL_COMPILE);
	gl.gluTessBeginPolygon(tobj, NULL);
	gl.gluTessBeginContour(tobj);
	for (i = 0; i < 4; i++)
		gl.gluTessVertex(tobj, rects[i], rects[i]);
	gl.gluTessEndContour(tobj);
	gl.gluTessBeginContour(tobj);
	for (i = 4; i < 8; i++)
		gl.gluTessVertex(tobj, rects[i], rects[i]);
	gl.gluTessEndContour(tobj);
	gl.gluTessBeginContour(tobj);
	for (i = 8; i < 12; i++)
		gl.gluTessVertex(tobj, rects[i], rects[i]);
	gl.gluTessEndContour(tobj);
	gl.gluTessEndPolygon(tobj);
	gl.glEndList();

	gl.glNewList(list + 1, GL.GL_COMPILE);
	gl.gluTessBeginPolygon(tobj, NULL);
	gl.gluTessBeginContour(tobj);
	for (i = 0; i < 4; i++)
		gl.gluTessVertex(tobj, rects[i], rects[i]);
	gl.gluTessEndContour(tobj);
	gl.gluTessBeginContour(tobj);
	for (i = 7; i >= 4; i--)
		gl.gluTessVertex(tobj, rects[i], rects[i]);
	gl.gluTessEndContour(tobj);
	gl.gluTessBeginContour(tobj);
	for (i = 11; i >= 8; i--)
		gl.gluTessVertex(tobj, rects[i], rects[i]);
	gl.gluTessEndContour(tobj);
	gl.gluTessEndPolygon(tobj);
	gl.glEndList();

	gl.glNewList(list + 2, GL.GL_COMPILE);
	gl.gluTessBeginPolygon(tobj, NULL);
	gl.gluTessBeginContour(tobj);
	for (i = 0; i < 16; i++)
		gl.gluTessVertex(tobj, spiral[i], spiral[i]);
	gl.gluTessEndContour(tobj);
	gl.gluTessEndPolygon(tobj);
	gl.glEndList();

	gl.glNewList(list + 3, GL.GL_COMPILE);
	gl.gluTessBeginPolygon(tobj, NULL);
	gl.gluTessBeginContour(tobj);
	for (i = 0; i < 4; i++)
		gl.gluTessVertex(tobj, quad1[i], quad1[i]);
	gl.gluTessEndContour(tobj);
	gl.gluTessBeginContour(tobj);
	for (i = 0; i < 4; i++)
		gl.gluTessVertex(tobj, quad2[i], quad2[i]);
	gl.gluTessEndContour(tobj);
	gl.gluTessBeginContour(tobj);
	for (i = 0; i < 3; i++)
		gl.gluTessVertex(tobj, tri[i], tri[i]);
	gl.gluTessEndContour(tobj);
	gl.gluTessEndPolygon(tobj);
	gl.glEndList();
}

void display(void) {
	gl.glClear(GL.GL_COLOR_BUFFER_BIT);
	gl.glColor3f(1.0f, 1.0f, 1.0f);
	gl.glPushMatrix();
	gl.glCallList(list);
	gl.glTranslatef(0.0f, 500.0f, 0.0f);
	gl.glCallList(list + 1);
	gl.glTranslatef(500.0f, -500.0f, 0.0f);
	gl.glCallList(list + 2);
	gl.glTranslatef(0.0f, 500.0f, 0.0f);
	gl.glCallList(list + 3);
	gl.glPopMatrix();
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

/*  combineCallback is used to create a new vertex when edges
 *  intersect.  coordinate location is trivial to calculate,
 *  but weight[4] may be used to average color, normal, or texture
 *  coordinate data.
 */
void CALLBACK combineCallback(GLdouble coords[3], GLdouble* data[4],
	GLfloat weight[4], GLdouble** dataOut)
{
	GLdouble* vertex;
	vertex = (GLdouble*)malloc(3 * sizeof(GLdouble));

	vertex[0] = coords[0];
	vertex[1] = coords[1];
	vertex[2] = coords[2];
	*dataOut = vertex;
}

void init(void)
{
	gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
	gl.glShadeModel(GL.GL_FLAT);

	tobj = gl.gluNewTess();
	gl.gluTessCallback(tobj, GLU_TESS_VERTEX,
		gl.glVertex3dv);
	gl.gluTessCallback(tobj, GLU_TESS_BEGIN,
		beginCallback);
	gl.gluTessCallback(tobj, GLU_TESS_END,
		endCallback);
	gl.gluTessCallback(tobj, GLU_TESS_ERROR,
		errorCallback);
	gl.gluTessCallback(tobj, GLU_TESS_COMBINE,
		combineCallback);

	list = gl.glGenLists(4);
	makeNewLists();
}

void reshape(int w, int h)
{
	gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
	gl.glMatrixMode(GL.GL_PROJECTION);
	gl.glLoadIdentity();
	if (w <= h)
		gl.gluOrtho2D(0.0f, 1000.0f, 0.0f, 1000.0f * (GLdouble)h / (GLdouble)w);
	else
		gl.gluOrtho2D(0.0f, 1000.0f * (GLdouble)w / (GLdouble)h, 0.0f, 1000.0f);
	gl.glMatrixMode(GL.GL_MODELVIEW);
	gl.glLoadIdentity();
}

void keyboard(unsigned char key, int x, int y)
{
	switch (key) {
	case 'w':
	case 'W':
		if (currentWinding == GLU_TESS_WINDING_ODD)
			currentWinding = GLU_TESS_WINDING_NONZERO;
		else if (currentWinding == GLU_TESS_WINDING_NONZERO)
			currentWinding = GLU_TESS_WINDING_POSITIVE;
		else if (currentWinding == GLU_TESS_WINDING_POSITIVE)
			currentWinding = GLU_TESS_WINDING_NEGATIVE;
		else if (currentWinding == GLU_TESS_WINDING_NEGATIVE)
			currentWinding = GLU_TESS_WINDING_ABS_GEQ_TWO;
		else if (currentWinding == GLU_TESS_WINDING_ABS_GEQ_TWO)
			currentWinding = GLU_TESS_WINDING_ODD;
		makeNewLists();
		gl.glutPostRedisplay();
		break;
	case 27:
		exit(0);
		break;
	default:
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
