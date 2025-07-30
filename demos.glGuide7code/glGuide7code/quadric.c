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
  *  quadric.c
  *  This program demonstrates the use of some of the gl.gluQuadric*
  *  routines. Quadric objects are created with some quadric
  *  properties and the callback routine to handle errors.
  *  Note that the cylinder has no top or bottom and the circle
  *  has a hole in it.
  */
#include <GL/glut.h>
#include <stdio.h>
#include <stdlib.h>

#ifndef CALLBACK
#define CALLBACK
#endif

GLuint startList;

void CALLBACK errorCallback(GLenum errorCode)
{
	const GLubyte* estring;

	estring = gl.gluErrorString(errorCode);
	fprintf(stderr, "Quadric Error: %s\n", estring);
	exit(0);
}

void init(void)
{
	GLUquadricObj* qobj;
	GLfloat mat_ambient[] = { 0.5f, 0.5f, 0.5f, 1.0f };
	GLfloat mat_specular[] = { 1.0f, 1.0f, 1.0f, 1.0f };
	GLfloat mat_shininess[] = { 50.0f };
	GLfloat light_position[] = { 1.0f, 1.0f, 1.0f, 0.0f };
	GLfloat model_ambient[] = { 0.5f, 0.5f, 0.5f, 1.0f };

	gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);

	gl.glMaterialfv(GL.GL_FRONT, GL.GL_AMBIENT, mat_ambient);
	gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, mat_specular);
	gl.glMaterialfv(GL.GL_FRONT, GL.GL_SHININESS, mat_shininess);
	gl.glLightfv(GL.GL_LIGHT0, GL.GL_POSITION, light_position);
	gl.glLightModelfv(GL.GL_LIGHT_MODEL_AMBIENT, model_ambient);

	gl.glEnable(GL.GL_LIGHTING);
	gl.glEnable(GL.GL_LIGHT0);
	gl.glEnable(GL.GL_DEPTH_TEST);

	/*  Create 4 display lists, each with a different quadric object.
	 *  Different drawing styles and surface normal specifications
	 *  are demonstrated.
	 */
	startList = gl.glGenLists(4);
	qobj = gl.gluNewQuadric();
	gl.gluQuadricCallback(qobj, GLU_ERROR,
		errorCallback);

	gl.gluQuadricDrawStyle(qobj, GLU_FILL); /* smooth shaded */
	gl.gluQuadricNormals(qobj, GLU_SMOOTH);
	gl.glNewList(startList, GL.GL_COMPILE);
	gl.gluSphere(qobj, 0.75f, 15, 10);
	gl.glEndList();

	gl.gluQuadricDrawStyle(qobj, GLU_FILL); /* flat shaded */
	gl.gluQuadricNormals(qobj, GLU_FLAT);
	gl.glNewList(startList + 1, GL.GL_COMPILE);
	gl.gluCylinder(qobj, 0.5f, 0.3f, 1.0f, 15, 5);
	gl.glEndList();

	gl.gluQuadricDrawStyle(qobj, GLU_LINE); /* all polygons wireframe */
	gl.gluQuadricNormals(qobj, GLU_NONE);
	gl.glNewList(startList + 2, GL.GL_COMPILE);
	gl.gluDisk(qobj, 0.25f, 1.0f, 20, 4);
	gl.glEndList();

	gl.gluQuadricDrawStyle(qobj, GLU_SILHOUETTE); /* boundary only  */
	gl.gluQuadricNormals(qobj, GLU_NONE);
	gl.glNewList(startList + 3, GL.GL_COMPILE);
	gl.gluPartialDisk(qobj, 0.0f, 1.0f, 20, 4, 0.0f, 225.0f);
	gl.glEndList();
}

void display(void)
{
	gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
	gl.glPushMatrix();

	gl.glEnable(GL.GL_LIGHTING);
	gl.glShadeModel(GL.GL_SMOOTH);
	gl.glTranslatef(-1.0f, -1.0f, 0.0f);
	gl.glCallList(startList);

	gl.glShadeModel(GL.GL_FLAT);
	gl.glTranslatef(0.0f, 2.0f, 0.0f);
	gl.glPushMatrix();
	gl.glRotatef(300.0f, 1.0f, 0.0f, 0.0f);
	gl.glCallList(startList + 1);
	gl.glPopMatrix();

	gl.glDisable(GL.GL_LIGHTING);
	gl.glColor3f(0.0f, 1.0f, 1.0f);
	gl.glTranslatef(2.0f, -2.0f, 0.0f);
	gl.glCallList(startList + 2);

	gl.glColor3f(1.0f, 1.0f, 0.0f);
	gl.glTranslatef(0.0f, 2.0f, 0.0f);
	gl.glCallList(startList + 3);

	gl.glPopMatrix();
	gl.glFlush();
}

void reshape(int w, int h)
{
	gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
	gl.glMatrixMode(GL.GL_PROJECTION);
	gl.glLoadIdentity();
	if (w <= h)
		gl.glOrtho(-2.5f, 2.5f, -2.5f * (GLfloat)h / (GLfloat)w,
			2.5f * (GLfloat)h / (GLfloat)w, -10.0f, 10.0f);
	else
		gl.glOrtho(-2.5f * (GLfloat)w / (GLfloat)h,
			2.5f * (GLfloat)w / (GLfloat)h, -2.5f, 2.5f, -10.0f, 10.0f);
	gl.glMatrixMode(GL.GL_MODELVIEW);
	gl.glLoadIdentity();
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
	gl.glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB | GLUT_DEPTH);
	gl.glutInitWindowSize(500, 500);
	gl.glutInitWindowPosition(100, 100);
	gl.glutCreateWindow(argv[0]);
	init();
	gl.glutDisplayFunc(display);
	gl.glutReshapeFunc(reshape);
	gl.glutKeyboardFunc(keyboard);
	gl.glutMainLoop();
	return 0;
}
