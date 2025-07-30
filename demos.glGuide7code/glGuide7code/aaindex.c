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
  *  aaindex.c
  *  This program draws shows how to draw anti-aliased lines in color
  *  index mode. It draws two diagonal lines to form an X; when 'r'
  *  is typed in the window, the lines are rotated in opposite
  *  directions.
  */
#include <GL/glut.h>
#include "stdlib.h"

#define RAMPSIZE 16
#define RAMP1START 32
#define RAMP2START 48

static float rotAngle = 0.0f;

/*  Initialize antialiasing for color index mode,
 *  including loading a green color ramp starting
 *  at RAMP1START, and a blue color ramp starting
 *  at RAMP2START. The ramps must be a multiple of 16.f
 */
void init(void)
{
	int i;

	for (i = 0; i < RAMPSIZE; i++) {
		GLfloat shade;
		shade = (GLfloat)i / (GLfloat)RAMPSIZE;
		gl.glutSetColor(RAMP1START + (GLint)i, 0.0f, shade, 0.0f);
		gl.glutSetColor(RAMP2START + (GLint)i, 0.0f, 0.0f, shade);
	}

	gl.glEnable(GL.GL_LINE_SMOOTH);
	gl.glHint(GL.GL_LINE_SMOOTH_HINT, GL.GL_DONT_CARE);
	gl.glLineWidth(1.5f);

	gl.glClearIndex((GLfloat)RAMP1START);
}

/*  Draw 2 diagonal lines to form an X
 */
void display(void)
{
	gl.glClear(GL.GL_COLOR_BUFFER_BIT);

	gl.glIndexi(RAMP1START);
	gl.glPushMatrix();
	gl.glRotatef(-rotAngle, 0.0f, 0.0f, 0.1f);
	gl.glBegin(GL.GL_LINES);
	gl.glVertex2f(-0.5f, 0.5f);
	gl.glVertex2f(0.5f, -0.5f);
	gl.glEnd();
	gl.glPopMatrix();

	gl.glIndexi(RAMP2START);
	gl.glPushMatrix();
	gl.glRotatef(rotAngle, 0.0f, 0.0f, 0.1f);
	gl.glBegin(GL.GL_LINES);
	gl.glVertex2f(0.5f, 0.5f);
	gl.glVertex2f(-0.5f, -0.5f);
	gl.glEnd();
	gl.glPopMatrix();

	gl.glFlush();
}

void reshape(int w, int h)
{
	gl.glViewport(0, 0, (GLsizei)w, (GLsizei)h);
	gl.glMatrixMode(GL.GL_PROJECTION);
	gl.glLoadIdentity();
	if (w <= h)
		gl.gluOrtho2D(-1.0f, 1.0f,
			-1.0f * (GLfloat)h / (GLfloat)w, 1.0f * (GLfloat)h / (GLfloat)w);
	else
		gl.gluOrtho2D(-1.0f * (GLfloat)w / (GLfloat)h,
			1.0f * (GLfloat)w / (GLfloat)h, -1.0f, 1.0f);
	gl.glMatrixMode(GL.GL_MODELVIEW);
	gl.glLoadIdentity();
}

void keyboard(unsigned char key, int x, int y)
{
	switch (key) {
	case 'r':
	case 'R':
		rotAngle += 20.f;
		if (rotAngle >= 360.f) rotAngle = 0.0f;
		gl.glutPostRedisplay();
		break;
	case 27:  /*  Escape Key */
		exit(0);
		break;
	default:
		break;
	}
}

/*  Main Loop
 *  Open window with initial window size, title bar,
 *  color index display mode, and handle input events.
 */
int main(int argc, char** argv)
{
	gl.glutInit(&argc, argv);
	gl.glutInitDisplayMode(GLUT_SINGLE | GLUT_INDEX);
	gl.glutInitWindowSize(200, 200);
	gl.glutCreateWindow(argv[0]);
	init();
	gl.glutReshapeFunc(reshape);
	gl.glutKeyboardFunc(keyboard);
	gl.glutDisplayFunc(display);
	gl.glutMainLoop();
	return 0;
}
