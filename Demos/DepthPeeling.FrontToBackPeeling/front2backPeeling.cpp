#define FOVY 30.0
#define ZNEAR 0.0001
#define ZFAR 10.0
#define FPS_TIME_WINDOW 1
#define MAX_DEPTH 1.0

int g_numPasses = 4;

GLuint g_quadDisplayList;

float g_opacity = 0.6;
unsigned g_numGeoPasses = 0;

float g_white[3] = { 1.0, 1.0, 1.0 };
float *g_backgroundColor = g_white;


GLSLProgramObject initProgram;
GLSLProgramObject peelProgram;
GLSLProgramObject blendProgram;
GLSLProgramObject finalProgram;

//--------------------------------------------------------------------------
void BuildShaders()
{
	initProgram.attachVertexShader(SHADER_PATH "shade_vertex.glsl");
	initProgram.attachVertexShader(SHADER_PATH "front_peeling_init_vertex.glsl");
	initProgram.attachFragmentShader(SHADER_PATH "shade_fragment.glsl");
	initProgram.attachFragmentShader(SHADER_PATH "front_peeling_init_fragment.glsl");
	initProgram.link();

	peelProgram.attachVertexShader(SHADER_PATH "shade_vertex.glsl");
	peelProgram.attachVertexShader(SHADER_PATH "front_peeling_peel_vertex.glsl");
	peelProgram.attachFragmentShader(SHADER_PATH "shade_fragment.glsl");
	peelProgram.attachFragmentShader(SHADER_PATH "front_peeling_peel_fragment.glsl");
	peelProgram.link();

	blendProgram.attachVertexShader(SHADER_PATH "front_peeling_blend_vertex.glsl");
	blendProgram.attachFragmentShader(SHADER_PATH "front_peeling_blend_fragment.glsl");
	blendProgram.link();

	finalProgram.attachVertexShader(SHADER_PATH "front_peeling_final_vertex.glsl");
	finalProgram.attachFragmentShader(SHADER_PATH "front_peeling_final_fragment.glsl");
	finalProgram.link();
}

//--------------------------------------------------------------------------
void DestroyShaders()
{
	initProgram.destroy();
	peelProgram.destroy();
	blendProgram.destroy();
	finalProgram.destroy();
}

//--------------------------------------------------------------------------
void RenderFrontToBackPeeling()
{
	// ---------------------------------------------------------------------
	// 1. Initialize Min Depth Buffer
	// ---------------------------------------------------------------------

	glBindFramebuffer(GL_FRAMEBUFFER, blenderFBO);

	glClearColor(0, 0, 0, 1);
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	glEnable(GL_DEPTH_TEST);

	initProgram.bind();
	initProgram.setUniform("Alpha", (float*)&g_opacity, 1);
	DrawModel();
	initProgram.unbind();

	CHECK_GL_ERRORS;

	// ---------------------------------------------------------------------
	// 2. Depth Peeling + Blending
	// ---------------------------------------------------------------------

	int numLayers = (g_numPasses - 1) * 2;
	for (int layer = 1; g_useOQ || layer < numLayers; layer++) {
		int currId = layer % 2;
		int prevId = 1 - currId;

		glBindFramebuffer(GL_FRAMEBUFFER, FBOs[currId]);

		glClearColor(0, 0, 0, 0);
		glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

		glDisable(GL_BLEND);
		glEnable(GL_DEPTH_TEST);

		if (g_useOQ) {
			glBeginQuery(GL_SAMPLES_PASSED, g_queryId);
		}

		peelProgram.bind();
		peelProgram.bindTextureRECT("DepthTex", depthTextures[prevId], 0);
		peelProgram.setUniform("Alpha", (float*)&g_opacity, 1);
		DrawModel();
		peelProgram.unbind();

		if (g_useOQ) {
			glEndQuery(GL_SAMPLES_PASSED);
		}

		CHECK_GL_ERRORS;

		glBindFramebuffer(GL_FRAMEBUFFER, blenderFBO);
		glDrawBuffer(drawBufferIndexes[0]);

		glDisable(GL_DEPTH_TEST);
		glEnable(GL_BLEND);

		glBlendEquation(GL_FUNC_ADD);
		glBlendFuncSeparate(GL_DST_ALPHA, GL_ONE, GL_ZERO, GL_ONE_MINUS_SRC_ALPHA);

		blendProgram.bind();
		blendProgram.bindTextureRECT("TempTex", colorTextures[currId], 0);
		glCallList(g_quadDisplayList);
		blendProgram.unbind();

		glDisable(GL_BLEND);

		CHECK_GL_ERRORS;

		if (g_useOQ) {
			GLuint sample_count;
			glGetQueryObjectuiv(g_queryId, GL_QUERY_RESULT, &sample_count);
			if (sample_count == 0) {
				break;
			}
		}
	}

	// ---------------------------------------------------------------------
	// 3. Final Pass
	// ---------------------------------------------------------------------

	glBindFramebuffer(GL_FRAMEBUFFER, 0);
	glDrawBuffer(GL_BACK);
	glDisable(GL_DEPTH_TEST);

	finalProgram.bind();
	finalProgram.setUniform("BackgroundColor", g_backgroundColor, 3);
	finalProgram.bindTextureRECT("ColorTex", blenderTexture, 0);
	glCallList(g_quadDisplayList);
	finalProgram.unbind();

	CHECK_GL_ERRORS;
}

//--------------------------------------------------------------------------
void MakeFullScreenQuad()
{
	g_quadDisplayList = glGenLists(1);
	glNewList(g_quadDisplayList, GL_COMPILE);

	glMatrixMode(GL_MODELVIEW);
	glPushMatrix();
	glLoadIdentity();
	gluOrtho2D(0.0, 1.0, 0.0, 1.0);
	glBegin(GL_QUADS);
	{
		glVertex2f(0.0, 0.0);
		glVertex2f(1.0, 0.0);
		glVertex2f(1.0, 1.0);
		glVertex2f(0.0, 1.0);
	}
	glEnd();
	glPopMatrix();

	glEndList();
}

GLuint FBOs[2];
GLuint colorTextures[2];
GLuint depthTextures[2];
GLuint blenderFBO;
GLuint blenderTexture;


GLenum drawBufferIndexes[] = { GL_COLOR_ATTACHMENT0,
GL_COLOR_ATTACHMENT1,
GL_COLOR_ATTACHMENT2,
GL_COLOR_ATTACHMENT3,
GL_COLOR_ATTACHMENT4,
GL_COLOR_ATTACHMENT5,
GL_COLOR_ATTACHMENT6
};

//--------------------------------------------------------------------------
void InitFrontPeelingRenderTargets(int width, int height)
{
	glGenTextures(2, depthTextures);
	glGenTextures(2, colorTextures);
	glGenFramebuffers(2, FBOs);

	for (int i = 0; i < 2; i++)
	{
		glBindTexture(TextureRect, depthTextures[i]);
		glTexParameteri(TextureRect, GL_TEXTURE_WRAP_S, GL_CLAMP);
		glTexParameteri(TextureRect, GL_TEXTURE_WRAP_T, GL_CLAMP);
		glTexParameteri(TextureRect, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
		glTexParameteri(TextureRect, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
		glTexImage2D(TextureRect, 0, GL_DEPTH_COMPONENT32F_NV, width, width, 0, GL_DEPTH_COMPONENT, GL_FLOAT, NULL);

		glBindTexture(TextureRect, colorTextures[i]);
		glTexParameteri(TextureRect, GL_TEXTURE_WRAP_S, GL_CLAMP);
		glTexParameteri(TextureRect, GL_TEXTURE_WRAP_T, GL_CLAMP);
		glTexParameteri(TextureRect, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
		glTexParameteri(TextureRect, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
		glTexImage2D(TextureRect, 0, GL_RGBA, width, width, 0, GL_RGBA, GL_FLOAT, 0);

		glBindFramebuffer(GL_FRAMEBUFFER, FBOs[i]);
		glFramebufferTexture2D(GL_FRAMEBUFFER, GL_DEPTH_ATTACHMENT, TextureRect, depthTextures[i], 0);
		glFramebufferTexture2D(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT0, TextureRect, colorTextures[i], 0);
	}

	// init front blender fbo.
	glGenTextures(1, &blenderTexture);
	glBindTexture(TextureRect, blenderTexture);
	glTexParameteri(TextureRect, GL_TEXTURE_WRAP_S, GL_CLAMP);
	glTexParameteri(TextureRect, GL_TEXTURE_WRAP_T, GL_CLAMP);
	glTexParameteri(TextureRect, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
	glTexParameteri(TextureRect, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
	glTexImage2D(TextureRect, 0, GL_RGBA, width, width, 0, GL_RGBA, GL_FLOAT, 0);

	glGenFramebuffers(1, &blenderFBO);
	glBindFramebuffer(GL_FRAMEBUFFER, blenderFBO);
	glFramebufferTexture2D(GL_FRAMEBUFFER, GL_DEPTH_ATTACHMENT, TextureRect, depthTextures[0], 0);
	glFramebufferTexture2D(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT0, TextureRect, blenderTexture, 0);
	CHECK_GL_ERRORS;
}

