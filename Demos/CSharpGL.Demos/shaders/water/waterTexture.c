/**
 * OpenGL 3 - Example 15
 *
 * @author	Norbert Nopper norbert@nopper.tv
 *
 * Homepage: http://nopper.tv
 *
 * Copyright Norbert Nopper
 */

#include <stdio.h>
#include <string.h>

#include "GL/glus.h"

#include "globals.h"

static GLUSprogram g_programWaterTexture;

static GLint g_projectionMatrixWaterTextureLocation;

static GLint g_modelViewMatrixWaterTextureLocation;

static GLint g_vertexWaterTextureLocation;

static GLint g_texCoordWaterTextureLocation;

static GLint g_waterPlaneLengthWaterTextureLocation;

static GLint g_passedTimeWaterTextureLocation;

static GLint g_waveDirectionsWaterTextureLocation;

//

static GLuint g_vaoWaterTexture;

static GLuint g_verticesWaterTextureVBO;

static GLuint g_texCoordsWaterTextureVBO;

static GLuint g_indicesWaterTextureVBO;

static GLuint g_numberIndicesWaterTexture;

//

static GLuint g_mirrorTexture;

static GLuint g_depthMirrorTexture;

//

static GLuint g_fboWaterTexture;

//

/**
 * Width of the parent/caller element.
 */
static GLuint g_parentWidth;

/**
 * Height of the parent/caller element.
 */
static GLuint g_parentHeight;

GLUSuint initWaterTexture(GLUSfloat waterPlaneLength)
{
	GLfloat projectionMatrixWaterTexture[16];
	GLfloat modelViewMatrixWaterTexture[16];

	GLUSshape plane;

	GLUStextfile vertexSource;
	GLUStextfile fragmentSource;

	glusFileLoadText("../Example15/shader/WaterTexture.vert.glsl", &vertexSource);
	glusFileLoadText("../Example15/shader/WaterTexture.frag.glsl", &fragmentSource);

	glusProgramBuildFromSource(&g_programWaterTexture, (const GLUSchar**)&vertexSource.text, 0, 0, 0, (const GLUSchar**)&fragmentSource.text);

	glusFileDestroyText(&vertexSource);
	glusFileDestroyText(&fragmentSource);

	//

	glClearColor(0.0f, 0.0f, 0.0f, 0.0f);

	glClearDepth(1.0f);

	glEnable(GL_DEPTH_TEST);

	glEnable(GL_CULL_FACE);

	return g_mirrorTexture;
}

GLUSvoid reshapeWaterTexture(GLUSint width, GLUSint height)
{
	// Store parent/caller width ..
	g_parentWidth = width;

	// ... and height for later usage to set to the original values
	g_parentHeight = height;
}
