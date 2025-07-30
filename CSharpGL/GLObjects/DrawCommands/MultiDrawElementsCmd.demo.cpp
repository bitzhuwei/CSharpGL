﻿/*
 * Copyright (c) 1993-2003, Silicon Graphics, Inc.
 * All Rights Reserved
 *
 * Permission to use, copy, modify, and distribute this software for any
 * purpose and without fee is hereby granted, provided that the above
 * copyright notice appear in all copies and that both the copyright
 * notice and this permission notice appear in supporting documentation,
 * and that the name of Silicon Graphics, Inc. not be used in
 * advertising or publicity pertaining to distribution of the software
 * without specific, written prior permission.
 *
 * THE MATERIAL EMBODIED ON THIS SOFTWARE IS PROVIDED TO YOU "AS-IS" AND
 * WITHOUT WARRANTY OF ANY KIND, EXPRESS, IMPLIED OR OTHERWISE,
 * INCLUDING WITHOUT LIMITATION, ANY WARRANTY OF MERCHANTABILITY OR
 * FITNESS FOR A PARTICULAR PURPOSE.  IN NO EVENT SHALL SILICON
 * GRAPHICS, INC.  BE LIABLE TO YOU OR ANYONE ELSE FOR ANY DIRECT,
 * SPECIAL, INCIDENTAL, INDIRECT OR CONSEQUENTIAL DAMAGES OF ANY KIND,
 * OR ANY DAMAGES WHATSOEVER, INCLUDING WITHOUT LIMITATION, LOSS OF
 * PROFIT, LOSS OF USE, SAVINGS OR REVENUE, OR THE CLAIMS OF THIRD
 * PARTIES, WHETHER OR NOT SILICON GRAPHICS, INC.  HAS BEEN ADVISED OF
 * THE POSSIBILITY OF SUCH LOSS, HOWEVER CAUSED AND ON ANY THEORY OF
 * LIABILITY, ARISING OUT OF OR IN CONNECTION WITH THE POSSESSION, USE
 * OR PERFORMANCE OF THIS SOFTWARE.
 *
 * US Government Users Restricted Rights
 * Use, duplication, or disclosure by the Government is subject to
 * restrictions set forth in FAR 52.227.19(c)(2) or subparagraph
 * (c)(1)(ii) of the Rights in Technical Data and Computer Software
 * clause at DFARS 252.227-7013 and/or in similar or successor clauses
 * in the FAR or the DOD or NASA FAR Supplement.  Unpublished - rights
 * reserved under the copyright laws of the United States.
 *
 * Contractor/manufacturer is:
 *  Silicon Graphics, Inc.
 *  1500 Crittenden Lane
 *  Mountain View, CA  94043
 *  United State of America
 *
 * OpenGL(R) is a registered trademark of Silicon Graphics, Inc.
 */

 /*
  *  mvarray.c
  *  This program demonstrates multiple vertex arrays,
  *  specifically the OpenGL routine glMultiDrawElements().
  */
#include <stdlib.h>  
#include <stdio.h>  
#include <GL/glew.h>          // 包含最新的gl.h,glu.h库  
#include <GL/glut.h>          // 包含OpenGL实用库  

#ifdef GL_VERSION_1_3  

void setupPointer_mvarray(void)
{
	static GLint vertices[] = { 25, 25,
		75, 75,
		100, 125,
		150, 75,
		200, 175,
		250, 150,
		300, 125,
		100, 200,
		150, 250,
		200, 225,
		250, 300,
		300, 250 };

	glEnableClientState(GL_VERTEX_ARRAY);
	glVertexPointer(2, GL_INT, 0, vertices);
}

void init_mvarray(void)
{
	glClearColor(0.0, 0.0, 0.0, 0.0);
	glShadeModel(GL_SMOOTH);
	setupPointer_mvarray();
}

void display_mvarray(void)
{
	static GLubyte oneIndices[] = { 0, 1, 2, 3, 4, 5, 6 };
	static GLubyte twoIndices[] = { 1, 7, 8, 9, 10, 11 };
	static GLsizei count[] = { 7, 6 };
	static GLvoid* indices[2] = { oneIndices, twoIndices };

	glClear(GL_COLOR_BUFFER_BIT);
	glColor3f(1.0, 1.0, 1.0);
	glMultiDrawElementsEXT(GL_LINE_STRIP, count, GL_UNSIGNED_BYTE,
		indices, 2);
	glFlush();
}

void reshape_mvarray(int w, int h)
{
	glViewport(0, 0, (GLsizei)w, (GLsizei)h);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(0.0, (GLdouble)w, 0.0, (GLdouble)h);
}

void keyboard_mvarray(unsigned char key, int x, int y)
{
	switch (key) {
	case 27:
		exit(0);
		break;
	}
}

int g_main_mvarray(int argc, char** argv)
{
	GLenum err;

	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowSize(350, 350);
	glutInitWindowPosition(100, 100);
	glutCreateWindow(argv[0]);

	err = gl.glewInit();
	if (GLEW_OK != err)
	{
		return 0;
	}

	init_mvarray();
	glutDisplayFunc(display_mvarray);
	glutReshapeFunc(reshape_mvarray);
	glutKeyboardFunc(keyboard_mvarray);
	glutMainLoop();
	return 0;
}
#else  
int main(int argc, char** argv)
{
	fprintf(stderr, "This program demonstrates a feature which is not in OpenGL Version 1.0./n");
	fprintf(stderr, "If your implementation of OpenGL Version 1.0 has the right extensions,/n");
	fprintf(stderr, "you may be able to modify this program to make it run./n");
	return 0;
}
#endif  