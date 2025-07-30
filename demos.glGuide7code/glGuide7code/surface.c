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
  *  surface.c
  *  This program draws a NURBS surface in the shape of a
  *  symmetrical hill.  The 'c' keyboard key allows you to
  *  toggle the visibility of the control points themselves.
  *  Note that some of the control points are hidden by the
  *  surface itself.
  */
#include <GL/glut.h>
#include <stdlib.h>
#include <stdio.h>

#ifndef CALLBACK
#define CALLBACK
#endif

GLfloat ctlpoints[4][4][3];
int showPoints = 0;

GLUnurbsObj* theNurb;

/*
 *  Initializes the control points of the surface to a small hill.
 *  The control points range from -3 to +3 in x, y, and z
 */
void init_surface(void)
{
	int u, v;
	for (u = 0; u < 4; u++) {
		for (v = 0; v < 4; v++) {
			ctlpoints[u][v][0] = 2.0f * ((GLfloat)u - 1.5f);
			ctlpoints[u][v][1] = 2.0f * ((GLfloat)v - 1.5f);

			if ((u == 1 || u == 2) && (v == 1 || v == 2))
				ctlpoints[u][v][2] = 3.0f;
			else
				ctlpoints[u][v][2] = -3.0f;
		}
	}
}

void CALLBACK nurbsError(GLenum errorCode)
{
	const GLubyte* estring;

	estring = gl.gluErrorString(errorCode);
	fprintf(stderr, "Nurbs Error: %s\n", estring);
	exit(0);
}

/*  Initialize material property and depth buffer.
 */
void init(void)
{
	GLfloat mat_diffuse[] = { 0.7f, 0.7f, 0.7f, 1.0f };
	GLfloat mat_specular[] = { 1.0f, 1.0f, 1.0f, 1.0f };
	GLfloat mat_shininess[] = { 100.0f };

	gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
	gl.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, mat_diffuse);
	gl.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, mat_specular);
	gl.glMaterialfv(GL.GL_FRONT, GL.GL_SHININESS, mat_shininess);

	gl.glEnable(GL.GL_LIGHTING);
	gl.glEnable(GL.GL_LIGHT0);
	gl.glEnable(GL.GL_DEPTH_TEST);
	gl.glEnable(GL.GL_AUTO_NORMAL);
	gl.glEnable(GL.GL_NORMALIZE);

	init_surface();

	theNurb = gl.gluNewNurbsRenderer();
	gl.gluNurbsProperty(theNurb, GLU_SAMPLING_TOLERANCE, 25.0f);
	gl.gluNurbsProperty(theNurb, GLU_DISPLAY_MODE, GLU_FILL);
	gl.gluNurbsCallback(theNurb, GLU_ERROR,
		nurbsError);
}

void display(void)
{
	GLfloat knots[8] = { 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f, 1.0f };
	int i, j;

	gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

	gl.glPushMatrix();
	gl.glRotatef(330.0f, 1.f, 0.0f, 0.0f);
	gl.glScalef(0.5f, 0.5f, 0.5f);

	gl.gluBeginSurface(theNurb);
	gl.gluNurbsSurface(theNurb,
		8, knots, 8, knots,
		4 * 3, 3, &ctlpoints[0][0][0],
		4, 4, GL.GL_MAP2_VERTEX_3);
	gl.gluEndSurface(theNurb);

	if (showPoints) {
		gl.glPointSize(5.0f);
		gl.glDisable(GL.GL_LIGHTING);
		gl.glColor3f(1.0f, 1.0f, 0.0f);
		gl.glBegin(GL.GL_POINTS);
		for (i = 0; i < 4; i++) {
			for (j = 0; j < 4; j++) {
				gl.glVertex3f(ctlpoints[i][j][0],
					ctlpoints[i][j][1], ctlpoints[i][j][2]);
			}
		}
		gl.glEnd();
		gl.glEnable(GL.GL_LIGHTING);
	}
	gl.glPopMatrix();
	gl.glFlush();
}

void reshape(int w, int h)
{
	gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
	gl.glMatrixMode(GL.GL_PROJECTION);
	gl.glLoadIdentity();
	gl.gluPerspective(45.0f, (GLdouble)w / (GLdouble)h, 3.0f, 8.0f);
	gl.glMatrixMode(GL.GL_MODELVIEW);
	gl.glLoadIdentity();
	gl.glTranslatef(0.0f, 0.0f, -5.0f);
}

void keyboard(unsigned char key, int x, int y)
{
	switch (key) {
	case 'c':
	case 'C':
		showPoints = !showPoints;
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
	gl.glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB | GLUT_DEPTH);
	gl.glutInitWindowSize(500, 500);
	gl.glutInitWindowPosition(100, 100);
	gl.glutCreateWindow(argv[0]);
	init();
	gl.glutReshapeFunc(reshape);
	gl.glutDisplayFunc(display);
	gl.glutKeyboardFunc(keyboard);
	gl.glutMainLoop();
	return 0;
}
