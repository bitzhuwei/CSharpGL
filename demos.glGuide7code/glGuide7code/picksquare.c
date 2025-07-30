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
  * picksquare.c
  * Use of multiple names and picking are demonstrated.
  * A 3x3 grid of squares is drawn.  When the left mouse
  * button is pressed, all squares under the cursor position
  * have their color changed.
  */
#include <stdlib.h>
#include <stdio.h>
#include <GL/glut.h>

int board[3][3];   /*  amount of color for each square	*/

/*  Clear color value for every square on the board   */
void init(void)
{
	int i, j;
	for (i = 0; i < 3; i++)
		for (j = 0; j < 3; j++)
			board[i][j] = 0;
	gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
}

/*  The nine squares are drawn.  In selection mode, each
 *  square is given two names:  one for the row and the
 *  other for the column on the grid.  The color of each
 *  square is determined by its position on the grid, and
 *  the value in the board[][] array.
 */
void drawSquares(GLenum mode)
{
	GLuint i, j;
	for (i = 0; i < 3; i++) {
		if (mode == GL.GL_SELECT)
			gl.glLoadName(i);
		for (j = 0; j < 3; j++) {
			if (mode == GL.GL_SELECT)
				gl.glPushName(j);
			gl.glColor3f((GLfloat)i / 3.0f, (GLfloat)j / 3.0f,
				(GLfloat)board[i][j] / 3.0f);
			gl.glRecti(i, j, i + 1, j + 1);
			if (mode == GL.GL_SELECT)
				gl.glPopName();
		}
	}
}

/*  processHits prints out the contents of the
 *  selection array.
 */
void processHits(GLint hits, GLuint buffer[])
{
	unsigned int i, j;
	GLuint ii, jj, names, * ptr;

	printf("hits = %d\n", hits);
	ptr = (GLuint*)buffer;
	for (i = 0; i < hits; i++) {	/*  for each hit  */
		names = *ptr;
		printf(" number of names for this hit = %d\n", names); ptr++;
		printf("  z1 is %g;", (float)*ptr / 0x7fffffff); ptr++;
		printf(" z2 is %g\n", (float)*ptr / 0x7fffffff); ptr++;
		printf("   names are ");
		for (j = 0; j < names; j++) { /*  for each name */
			printf("%d ", *ptr);
			if (j == 0)  /*  set row and column  */
				ii = *ptr;
			else if (j == 1)
				jj = *ptr;
			ptr++;
		}
		printf("\n");
		board[ii][jj] = (board[ii][jj] + 1) % 3;
	}
}

/*  pickSquares() sets up selection mode, name stack,
 *  and projection matrix for picking.  Then the
 *  objects are drawn.
 */
#define BUFSIZE 512

void pickSquares(int button, int state, int x, int y)
{
	GLuint selectBuf[BUFSIZE];
	GLint hits;
	GLint viewport[4];

	if (button != GLUT_LEFT_BUTTON || state != GLUT_DOWN)
		return;

	gl.glGetIntegerv(GL.GL_VIEWPORT, viewport);

	gl.glSelectBuffer(BUFSIZE, selectBuf);
	(void)glRenderMode(GL.GL_SELECT);

	gl.glInitNames();
	gl.glPushName(0);

	gl.glMatrixMode(GL.GL_PROJECTION);
	gl.glPushMatrix();
	gl.glLoadIdentity();
	/*  create 5x5 pixel picking region near cursor location	*/
	gl.gluPickMatrix((GLdouble)x, (GLdouble)(viewport[3] - y),
		5.0f, 5.0f, viewport);
	gl.gluOrtho2D(0.0f, 3.0f, 0.0f, 3.0f);
	drawSquares(GL.GL_SELECT);

	gl.glMatrixMode(GL.GL_PROJECTION);
	gl.glPopMatrix();
	gl.glFlush();

	hits = gl.glRenderMode(GL.GL_RENDER);
	processHits(hits, selectBuf);
	gl.glutPostRedisplay();
}

void display(void)
{
	gl.glClear(GL.GL_COLOR_BUFFER_BIT);
	drawSquares(GL.GL_RENDER);
	gl.glFlush();
}

void reshape(int w, int h)
{
	gl.glViewport(0, 0, w, h);
	gl.glMatrixMode(GL.GL_PROJECTION);
	gl.glLoadIdentity();
	gl.gluOrtho2D(0.0f, 3.0f, 0.0f, 3.0f);
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

/* Main Loop */
int main(int argc, char** argv)
{
	gl.glutInit(&argc, argv);
	gl.glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	gl.glutInitWindowSize(100, 100);
	gl.glutInitWindowPosition(100, 100);
	gl.glutCreateWindow(argv[0]);
	init();
	gl.glutReshapeFunc(reshape);
	gl.glutDisplayFunc(display);
	gl.glutMouseFunc(pickSquares);
	gl.glutKeyboardFunc(keyboard);
	gl.glutMainLoop();
	return 0;
}
