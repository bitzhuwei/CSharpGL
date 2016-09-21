static GLfloat g_projectionMatrix[16];

static GLfloat g_viewMatrix[16];

static GLfloat g_inverseViewNormalMatrix[9];

//

static GLUSprogram g_program;

static GLint g_projectionMatrixLocation;

static GLint g_viewMatrixLocation;

static GLint g_inverseViewNormalMatrixLocation;

static GLint g_waterPlaneLengthLocation;

static GLint g_passedTimeLocation;

static GLint g_waveParametersLocation;

static GLint g_waveDirectionsLocation;

static GLint g_vertexLocation;

static GLint g_cubemapLocation;

static GLint g_waterTextureLocation;

//

static GLuint g_vao;

static GLuint g_verticesVBO;

static GLuint g_indicesVBO;

//

static GLuint g_cubemap;

GLUSboolean init(GLUSvoid)
{
	GLUStgaimage image;

	GLuint waterTexture;

	g_projectionMatrixLocation = glGetUniformLocation(g_program.program, "u_projectionMatrix");
	g_viewMatrixLocation = glGetUniformLocation(g_program.program, "u_viewMatrix");
	g_inverseViewNormalMatrixLocation = glGetUniformLocation(g_program.program, "u_inverseViewNormalMatrix");

	g_waterPlaneLengthLocation = glGetUniformLocation(g_program.program, "u_waterPlaneLength");

	g_cubemapLocation = glGetUniformLocation(g_program.program, "u_cubemap");

	g_waterTextureLocation = glGetUniformLocation(g_program.program, "u_waterTexture");

	g_passedTimeLocation = glGetUniformLocation(g_program.program, "u_passedTime");

	g_waveParametersLocation = glGetUniformLocation(g_program.program, "u_waveParameters");
	g_waveDirectionsLocation = glGetUniformLocation(g_program.program, "u_waveDirections");

	g_vertexLocation = glGetAttribLocation(g_program.program, "a_vertex");

	//

	waterTexture = initWaterTexture((GLUSfloat)WATER_PLANE_LENGTH);

	//

	initBackground();

	//

	//glClearColor(0.0f, 0.0f, 0.0f, 0.0f);

	//glClearDepth(1.0f);

	//glEnable(GL_DEPTH_TEST);

	//glEnable(GL_CULL_FACE);

	return GLUS_TRUE;
}

GLUSvoid reshape(GLUSint width, GLUSint height)
{
	glViewport(0, 0, width, height);

	glusMatrix4x4Perspectivef(g_projectionMatrix, 40.0f, (GLfloat)width / (GLfloat)height, 1.0f, 1000.0f);

	reshapeBackground(g_projectionMatrix);

	reshapeWaterTexture(width, height);

	glUseProgram(g_program.program);

	glUniformMatrix4fv(g_projectionMatrixLocation, 1, GL_FALSE, g_projectionMatrix);
}

/**
 * Main entry point.
 */
int main(int argc, char* argv[])
{

	glusWindowSetInitFunc(init);

	glusWindowSetReshapeFunc(reshape);


	return 0;
}