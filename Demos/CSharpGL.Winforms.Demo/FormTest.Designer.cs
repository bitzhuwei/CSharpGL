namespace CSharpGL.Winforms.Demo
{
    partial class FormTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTest));
            this.btnBasis = new System.Windows.Forms.Button();
            this.btnCylinderElement = new System.Windows.Forms.Button();
            this.btnFormFontElement = new System.Windows.Forms.Button();
            this.btnPyramidElement = new System.Windows.Forms.Button();
            this.btnCamera = new System.Windows.Forms.Button();
            this.btnSatelliteRotation = new System.Windows.Forms.Button();
            this.btnFormWholeFontTextureElement = new System.Windows.Forms.Button();
            this.btnTranslateOnScreen = new System.Windows.Forms.Button();
            this.btnLegacySimpleUIRect = new System.Windows.Forms.Button();
            this.btnSimpleUIRect = new System.Windows.Forms.Button();
            this.btnSimpleUIAxis = new System.Windows.Forms.Button();
            this.btnSimpleUIColorPalette = new System.Windows.Forms.Button();
            this.btnSimpleUICube = new System.Windows.Forms.Button();
            this.btnDebugging = new System.Windows.Forms.Button();
            this.btnSimplePointSprite = new System.Windows.Forms.Button();
            this.btnFormPointSpriteStringElement = new System.Windows.Forms.Button();
            this.btnFormLegacyTexture3D = new System.Windows.Forms.Button();
            this.btnFormColorCodedPicking = new System.Windows.Forms.Button();
            this.btnFormScientificVisual3DControl = new System.Windows.Forms.Button();
            this.btnFormTransformFeedback = new System.Windows.Forms.Button();
            this.btnFormInstancedRendering = new System.Windows.Forms.Button();
            this.btnFormMapBuffer = new System.Windows.Forms.Button();
            this.btnTexImage2D = new System.Windows.Forms.Button();
            this.btnFormMultipleHexahedrons1 = new System.Windows.Forms.Button();
            this.btnFormMultipleHexahedrons2 = new System.Windows.Forms.Button();
            this.btnFormLegacyTexture3D2 = new System.Windows.Forms.Button();
            this.btnFormVolumeRendering01 = new System.Windows.Forms.Button();
            this.btnFormVolumeRendering_Hexahedron = new System.Windows.Forms.Button();
            this.btnVR01_modernOpenGL_Quads = new System.Windows.Forms.Button();
            this.btnVR02_modernOpenGL_Points = new System.Windows.Forms.Button();
            this.btnFormVolumeRendering04 = new System.Windows.Forms.Button();
            this.btnFormVolumeRendering05 = new System.Windows.Forms.Button();
            this.btnFromShaderDesigner1594 = new System.Windows.Forms.Button();
            this.btnFormDoubleTexture = new System.Windows.Forms.Button();
            this.btnFormNormalLine = new System.Windows.Forms.Button();
            this.btnFormSimpleRenderer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBasis
            // 
            this.btnBasis.Location = new System.Drawing.Point(13, 13);
            this.btnBasis.Margin = new System.Windows.Forms.Padding(4);
            this.btnBasis.Name = "btnBasis";
            this.btnBasis.Size = new System.Drawing.Size(353, 29);
            this.btnBasis.TabIndex = 6;
            this.btnBasis.Text = "all kinds of basic codes";
            this.btnBasis.UseVisualStyleBackColor = true;
            this.btnBasis.Click += new System.EventHandler(this.btnBasis_Click);
            // 
            // btnCylinderElement
            // 
            this.btnCylinderElement.Location = new System.Drawing.Point(13, 161);
            this.btnCylinderElement.Margin = new System.Windows.Forms.Padding(4);
            this.btnCylinderElement.Name = "btnCylinderElement";
            this.btnCylinderElement.Size = new System.Drawing.Size(353, 29);
            this.btnCylinderElement.TabIndex = 1;
            this.btnCylinderElement.Text = "CylinderElement+SatelliteRotation";
            this.btnCylinderElement.UseVisualStyleBackColor = true;
            this.btnCylinderElement.Click += new System.EventHandler(this.btnCylinderElement_Click);
            // 
            // btnFormFontElement
            // 
            this.btnFormFontElement.Location = new System.Drawing.Point(13, 272);
            this.btnFormFontElement.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormFontElement.Name = "btnFormFontElement";
            this.btnFormFontElement.Size = new System.Drawing.Size(353, 29);
            this.btnFormFontElement.TabIndex = 4;
            this.btnFormFontElement.Text = "FormFontElement";
            this.btnFormFontElement.UseVisualStyleBackColor = true;
            this.btnFormFontElement.Click += new System.EventHandler(this.btnFormFontElement_Click);
            // 
            // btnPyramidElement
            // 
            this.btnPyramidElement.Location = new System.Drawing.Point(13, 50);
            this.btnPyramidElement.Margin = new System.Windows.Forms.Padding(4);
            this.btnPyramidElement.Name = "btnPyramidElement";
            this.btnPyramidElement.Size = new System.Drawing.Size(353, 29);
            this.btnPyramidElement.TabIndex = 5;
            this.btnPyramidElement.Text = "PyramidElement";
            this.btnPyramidElement.UseVisualStyleBackColor = true;
            this.btnPyramidElement.Click += new System.EventHandler(this.btnPyramidElement_Click);
            // 
            // btnCamera
            // 
            this.btnCamera.Enabled = false;
            this.btnCamera.Location = new System.Drawing.Point(13, 87);
            this.btnCamera.Margin = new System.Windows.Forms.Padding(4);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(353, 29);
            this.btnCamera.TabIndex = 3;
            this.btnCamera.Text = "PyramidElement+Camera(MouseWheel)";
            this.btnCamera.UseVisualStyleBackColor = true;
            // 
            // btnSatelliteRotation
            // 
            this.btnSatelliteRotation.Location = new System.Drawing.Point(13, 124);
            this.btnSatelliteRotation.Margin = new System.Windows.Forms.Padding(4);
            this.btnSatelliteRotation.Name = "btnSatelliteRotation";
            this.btnSatelliteRotation.Size = new System.Drawing.Size(353, 29);
            this.btnSatelliteRotation.TabIndex = 2;
            this.btnSatelliteRotation.Text = "PyramidElement+SatelliteRotation";
            this.btnSatelliteRotation.UseVisualStyleBackColor = true;
            this.btnSatelliteRotation.Click += new System.EventHandler(this.btnSatelliteRotation_Click);
            // 
            // btnFormWholeFontTextureElement
            // 
            this.btnFormWholeFontTextureElement.Location = new System.Drawing.Point(13, 235);
            this.btnFormWholeFontTextureElement.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormWholeFontTextureElement.Name = "btnFormWholeFontTextureElement";
            this.btnFormWholeFontTextureElement.Size = new System.Drawing.Size(353, 29);
            this.btnFormWholeFontTextureElement.TabIndex = 0;
            this.btnFormWholeFontTextureElement.Text = "FormWholeFontTextureElement";
            this.btnFormWholeFontTextureElement.UseVisualStyleBackColor = true;
            this.btnFormWholeFontTextureElement.Click += new System.EventHandler(this.btnFormWholeFontTextureElement_Click);
            // 
            // btnTranslateOnScreen
            // 
            this.btnTranslateOnScreen.Location = new System.Drawing.Point(13, 309);
            this.btnTranslateOnScreen.Margin = new System.Windows.Forms.Padding(4);
            this.btnTranslateOnScreen.Name = "btnTranslateOnScreen";
            this.btnTranslateOnScreen.Size = new System.Drawing.Size(353, 29);
            this.btnTranslateOnScreen.TabIndex = 4;
            this.btnTranslateOnScreen.Text = "TranslateOnScreen";
            this.btnTranslateOnScreen.UseVisualStyleBackColor = true;
            this.btnTranslateOnScreen.Click += new System.EventHandler(this.btnTranslateOnScreen_Click);
            // 
            // btnLegacySimpleUIRect
            // 
            this.btnLegacySimpleUIRect.Location = new System.Drawing.Point(13, 346);
            this.btnLegacySimpleUIRect.Margin = new System.Windows.Forms.Padding(4);
            this.btnLegacySimpleUIRect.Name = "btnLegacySimpleUIRect";
            this.btnLegacySimpleUIRect.Size = new System.Drawing.Size(353, 29);
            this.btnLegacySimpleUIRect.TabIndex = 4;
            this.btnLegacySimpleUIRect.Text = "LegacySimpleUIRect";
            this.btnLegacySimpleUIRect.UseVisualStyleBackColor = true;
            this.btnLegacySimpleUIRect.Click += new System.EventHandler(this.btnLegacySimpleUIRect_Click);
            // 
            // btnSimpleUIRect
            // 
            this.btnSimpleUIRect.Location = new System.Drawing.Point(13, 383);
            this.btnSimpleUIRect.Margin = new System.Windows.Forms.Padding(4);
            this.btnSimpleUIRect.Name = "btnSimpleUIRect";
            this.btnSimpleUIRect.Size = new System.Drawing.Size(353, 29);
            this.btnSimpleUIRect.TabIndex = 4;
            this.btnSimpleUIRect.Text = "SimpleUIRect";
            this.btnSimpleUIRect.UseVisualStyleBackColor = true;
            this.btnSimpleUIRect.Click += new System.EventHandler(this.btnSimpleUIRect_Click);
            // 
            // btnSimpleUIAxis
            // 
            this.btnSimpleUIAxis.Location = new System.Drawing.Point(13, 420);
            this.btnSimpleUIAxis.Margin = new System.Windows.Forms.Padding(4);
            this.btnSimpleUIAxis.Name = "btnSimpleUIAxis";
            this.btnSimpleUIAxis.Size = new System.Drawing.Size(353, 29);
            this.btnSimpleUIAxis.TabIndex = 4;
            this.btnSimpleUIAxis.Text = "SimpleUIAxis";
            this.btnSimpleUIAxis.UseVisualStyleBackColor = true;
            this.btnSimpleUIAxis.Click += new System.EventHandler(this.btnSimpleUIAxis_Click);
            // 
            // btnSimpleUIColorPalette
            // 
            this.btnSimpleUIColorPalette.Location = new System.Drawing.Point(13, 494);
            this.btnSimpleUIColorPalette.Margin = new System.Windows.Forms.Padding(4);
            this.btnSimpleUIColorPalette.Name = "btnSimpleUIColorPalette";
            this.btnSimpleUIColorPalette.Size = new System.Drawing.Size(353, 29);
            this.btnSimpleUIColorPalette.TabIndex = 4;
            this.btnSimpleUIColorPalette.Text = "SimpleUIColorPalette";
            this.btnSimpleUIColorPalette.UseVisualStyleBackColor = true;
            this.btnSimpleUIColorPalette.Click += new System.EventHandler(this.btnSimpleUIColorPalette_Click);
            // 
            // btnSimpleUICube
            // 
            this.btnSimpleUICube.Location = new System.Drawing.Point(13, 457);
            this.btnSimpleUICube.Margin = new System.Windows.Forms.Padding(4);
            this.btnSimpleUICube.Name = "btnSimpleUICube";
            this.btnSimpleUICube.Size = new System.Drawing.Size(353, 29);
            this.btnSimpleUICube.TabIndex = 4;
            this.btnSimpleUICube.Text = "SimpleUICube";
            this.btnSimpleUICube.UseVisualStyleBackColor = true;
            this.btnSimpleUICube.Click += new System.EventHandler(this.btnSimpleUICube_Click);
            // 
            // btnDebugging
            // 
            this.btnDebugging.Location = new System.Drawing.Point(13, 531);
            this.btnDebugging.Margin = new System.Windows.Forms.Padding(4);
            this.btnDebugging.Name = "btnDebugging";
            this.btnDebugging.Size = new System.Drawing.Size(353, 29);
            this.btnDebugging.TabIndex = 4;
            this.btnDebugging.Text = "Debugging and profiling";
            this.btnDebugging.UseVisualStyleBackColor = true;
            this.btnDebugging.Click += new System.EventHandler(this.btnDebugging_Click);
            // 
            // btnSimplePointSprite
            // 
            this.btnSimplePointSprite.Location = new System.Drawing.Point(13, 605);
            this.btnSimplePointSprite.Margin = new System.Windows.Forms.Padding(4);
            this.btnSimplePointSprite.Name = "btnSimplePointSprite";
            this.btnSimplePointSprite.Size = new System.Drawing.Size(353, 29);
            this.btnSimplePointSprite.TabIndex = 4;
            this.btnSimplePointSprite.Text = "SimplePointSprite";
            this.btnSimplePointSprite.UseVisualStyleBackColor = true;
            this.btnSimplePointSprite.Click += new System.EventHandler(this.btnSimplePointSprite_Click);
            // 
            // btnFormPointSpriteStringElement
            // 
            this.btnFormPointSpriteStringElement.Location = new System.Drawing.Point(13, 568);
            this.btnFormPointSpriteStringElement.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormPointSpriteStringElement.Name = "btnFormPointSpriteStringElement";
            this.btnFormPointSpriteStringElement.Size = new System.Drawing.Size(353, 29);
            this.btnFormPointSpriteStringElement.TabIndex = 4;
            this.btnFormPointSpriteStringElement.Text = "FormPointSpriteStringElement";
            this.btnFormPointSpriteStringElement.UseVisualStyleBackColor = true;
            this.btnFormPointSpriteStringElement.Click += new System.EventHandler(this.btnFormPointSpriteStringElement_Click);
            // 
            // btnFormLegacyTexture3D
            // 
            this.btnFormLegacyTexture3D.Location = new System.Drawing.Point(13, 642);
            this.btnFormLegacyTexture3D.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormLegacyTexture3D.Name = "btnFormLegacyTexture3D";
            this.btnFormLegacyTexture3D.Size = new System.Drawing.Size(353, 29);
            this.btnFormLegacyTexture3D.TabIndex = 4;
            this.btnFormLegacyTexture3D.Text = "FormLegacyTexture3D";
            this.btnFormLegacyTexture3D.UseVisualStyleBackColor = true;
            this.btnFormLegacyTexture3D.Click += new System.EventHandler(this.btnFormLegacyTexture3D_Click);
            // 
            // btnFormColorCodedPicking
            // 
            this.btnFormColorCodedPicking.Location = new System.Drawing.Point(13, 679);
            this.btnFormColorCodedPicking.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormColorCodedPicking.Name = "btnFormColorCodedPicking";
            this.btnFormColorCodedPicking.Size = new System.Drawing.Size(353, 29);
            this.btnFormColorCodedPicking.TabIndex = 4;
            this.btnFormColorCodedPicking.Text = "FormColorCodedPicking";
            this.btnFormColorCodedPicking.UseVisualStyleBackColor = true;
            this.btnFormColorCodedPicking.Click += new System.EventHandler(this.btnFormColorCodedPicking_Click);
            // 
            // btnFormScientificVisual3DControl
            // 
            this.btnFormScientificVisual3DControl.Location = new System.Drawing.Point(374, 13);
            this.btnFormScientificVisual3DControl.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormScientificVisual3DControl.Name = "btnFormScientificVisual3DControl";
            this.btnFormScientificVisual3DControl.Size = new System.Drawing.Size(346, 29);
            this.btnFormScientificVisual3DControl.TabIndex = 4;
            this.btnFormScientificVisual3DControl.Text = "FormScientificVisual3DControl";
            this.btnFormScientificVisual3DControl.UseVisualStyleBackColor = true;
            this.btnFormScientificVisual3DControl.Click += new System.EventHandler(this.btnFormScientificVisual3DControl_Click);
            // 
            // btnFormTransformFeedback
            // 
            this.btnFormTransformFeedback.Location = new System.Drawing.Point(374, 50);
            this.btnFormTransformFeedback.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormTransformFeedback.Name = "btnFormTransformFeedback";
            this.btnFormTransformFeedback.Size = new System.Drawing.Size(346, 29);
            this.btnFormTransformFeedback.TabIndex = 4;
            this.btnFormTransformFeedback.Text = "FormTransformFeedback";
            this.btnFormTransformFeedback.UseVisualStyleBackColor = true;
            this.btnFormTransformFeedback.Click += new System.EventHandler(this.btnFormTransformFeedback_Click);
            // 
            // btnFormInstancedRendering
            // 
            this.btnFormInstancedRendering.Enabled = false;
            this.btnFormInstancedRendering.Location = new System.Drawing.Point(374, 87);
            this.btnFormInstancedRendering.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormInstancedRendering.Name = "btnFormInstancedRendering";
            this.btnFormInstancedRendering.Size = new System.Drawing.Size(346, 29);
            this.btnFormInstancedRendering.TabIndex = 4;
            this.btnFormInstancedRendering.Text = "FormInstancedRendering";
            this.btnFormInstancedRendering.UseVisualStyleBackColor = true;
            this.btnFormInstancedRendering.Click += new System.EventHandler(this.btnFormInstancedRendering_Click);
            // 
            // btnFormMapBuffer
            // 
            this.btnFormMapBuffer.Location = new System.Drawing.Point(374, 124);
            this.btnFormMapBuffer.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormMapBuffer.Name = "btnFormMapBuffer";
            this.btnFormMapBuffer.Size = new System.Drawing.Size(346, 29);
            this.btnFormMapBuffer.TabIndex = 4;
            this.btnFormMapBuffer.Text = "FormMapBuffer";
            this.btnFormMapBuffer.UseVisualStyleBackColor = true;
            this.btnFormMapBuffer.Click += new System.EventHandler(this.btnFormMapBuffer_Click);
            // 
            // btnTexImage2D
            // 
            this.btnTexImage2D.Location = new System.Drawing.Point(13, 198);
            this.btnTexImage2D.Margin = new System.Windows.Forms.Padding(4);
            this.btnTexImage2D.Name = "btnTexImage2D";
            this.btnTexImage2D.Size = new System.Drawing.Size(353, 29);
            this.btnTexImage2D.TabIndex = 1;
            this.btnTexImage2D.Text = "TexImage2D";
            this.btnTexImage2D.UseVisualStyleBackColor = true;
            this.btnTexImage2D.Click += new System.EventHandler(this.btnTexImage2D_Click);
            // 
            // btnFormMultipleHexahedrons1
            // 
            this.btnFormMultipleHexahedrons1.Location = new System.Drawing.Point(374, 161);
            this.btnFormMultipleHexahedrons1.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormMultipleHexahedrons1.Name = "btnFormMultipleHexahedrons1";
            this.btnFormMultipleHexahedrons1.Size = new System.Drawing.Size(346, 29);
            this.btnFormMultipleHexahedrons1.TabIndex = 4;
            this.btnFormMultipleHexahedrons1.Text = "FormMultipleHexahedrons1-DrawElements";
            this.btnFormMultipleHexahedrons1.UseVisualStyleBackColor = true;
            this.btnFormMultipleHexahedrons1.Click += new System.EventHandler(this.btnFormMultipleHexahedrons1_Click);
            // 
            // btnFormMultipleHexahedrons2
            // 
            this.btnFormMultipleHexahedrons2.Location = new System.Drawing.Point(374, 198);
            this.btnFormMultipleHexahedrons2.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormMultipleHexahedrons2.Name = "btnFormMultipleHexahedrons2";
            this.btnFormMultipleHexahedrons2.Size = new System.Drawing.Size(346, 29);
            this.btnFormMultipleHexahedrons2.TabIndex = 4;
            this.btnFormMultipleHexahedrons2.Text = "FormMultipleHexahedrons2-MultiDrawArrays";
            this.btnFormMultipleHexahedrons2.UseVisualStyleBackColor = true;
            this.btnFormMultipleHexahedrons2.Click += new System.EventHandler(this.btnFormMultipleHexahedrons2_Click);
            // 
            // btnFormLegacyTexture3D2
            // 
            this.btnFormLegacyTexture3D2.Location = new System.Drawing.Point(374, 235);
            this.btnFormLegacyTexture3D2.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormLegacyTexture3D2.Name = "btnFormLegacyTexture3D2";
            this.btnFormLegacyTexture3D2.Size = new System.Drawing.Size(346, 29);
            this.btnFormLegacyTexture3D2.TabIndex = 4;
            this.btnFormLegacyTexture3D2.Text = "FormLegacyTexture3D-2";
            this.btnFormLegacyTexture3D2.UseVisualStyleBackColor = true;
            this.btnFormLegacyTexture3D2.Click += new System.EventHandler(this.btnFormLegacyTexture3D2_Click);
            // 
            // btnFormVolumeRendering01
            // 
            this.btnFormVolumeRendering01.Location = new System.Drawing.Point(374, 272);
            this.btnFormVolumeRendering01.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormVolumeRendering01.Name = "btnFormVolumeRendering01";
            this.btnFormVolumeRendering01.Size = new System.Drawing.Size(346, 29);
            this.btnFormVolumeRendering01.TabIndex = 4;
            this.btnFormVolumeRendering01.Text = "FormVolumeRendering00-legacy opengl";
            this.btnFormVolumeRendering01.UseVisualStyleBackColor = true;
            this.btnFormVolumeRendering01.Click += new System.EventHandler(this.btnFormVolumeRendering01_Click);
            // 
            // btnFormVolumeRendering_Hexahedron
            // 
            this.btnFormVolumeRendering_Hexahedron.Location = new System.Drawing.Point(374, 383);
            this.btnFormVolumeRendering_Hexahedron.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormVolumeRendering_Hexahedron.Name = "btnFormVolumeRendering_Hexahedron";
            this.btnFormVolumeRendering_Hexahedron.Size = new System.Drawing.Size(346, 29);
            this.btnFormVolumeRendering_Hexahedron.TabIndex = 4;
            this.btnFormVolumeRendering_Hexahedron.Text = "FormVolumeRendering03-hexahedron";
            this.btnFormVolumeRendering_Hexahedron.UseVisualStyleBackColor = true;
            this.btnFormVolumeRendering_Hexahedron.Click += new System.EventHandler(this.btnFormVolumeRendering_Hexahedron_Click);
            // 
            // btnVR01_modernOpenGL_Quads
            // 
            this.btnVR01_modernOpenGL_Quads.Location = new System.Drawing.Point(374, 309);
            this.btnVR01_modernOpenGL_Quads.Margin = new System.Windows.Forms.Padding(4);
            this.btnVR01_modernOpenGL_Quads.Name = "btnVR01_modernOpenGL_Quads";
            this.btnVR01_modernOpenGL_Quads.Size = new System.Drawing.Size(346, 29);
            this.btnVR01_modernOpenGL_Quads.TabIndex = 4;
            this.btnVR01_modernOpenGL_Quads.Text = "FormVolumeRendering01-quads";
            this.btnVR01_modernOpenGL_Quads.UseVisualStyleBackColor = true;
            this.btnVR01_modernOpenGL_Quads.Click += new System.EventHandler(this.btnVR01_modernOpenGL_Quads_Click);
            // 
            // btnVR02_modernOpenGL_Points
            // 
            this.btnVR02_modernOpenGL_Points.Location = new System.Drawing.Point(374, 346);
            this.btnVR02_modernOpenGL_Points.Margin = new System.Windows.Forms.Padding(4);
            this.btnVR02_modernOpenGL_Points.Name = "btnVR02_modernOpenGL_Points";
            this.btnVR02_modernOpenGL_Points.Size = new System.Drawing.Size(346, 29);
            this.btnVR02_modernOpenGL_Points.TabIndex = 4;
            this.btnVR02_modernOpenGL_Points.Text = "FormVolumeRendering02-points";
            this.btnVR02_modernOpenGL_Points.UseVisualStyleBackColor = true;
            this.btnVR02_modernOpenGL_Points.Click += new System.EventHandler(this.btnVR02_modernOpenGL_Points_Click);
            // 
            // btnFormVolumeRendering04
            // 
            this.btnFormVolumeRendering04.Location = new System.Drawing.Point(374, 420);
            this.btnFormVolumeRendering04.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormVolumeRendering04.Name = "btnFormVolumeRendering04";
            this.btnFormVolumeRendering04.Size = new System.Drawing.Size(346, 29);
            this.btnFormVolumeRendering04.TabIndex = 4;
            this.btnFormVolumeRendering04.Text = "FormVolumeRendering04-doubleRender-quads";
            this.btnFormVolumeRendering04.UseVisualStyleBackColor = true;
            this.btnFormVolumeRendering04.Click += new System.EventHandler(this.btnFormVolumeRendering04_Click);
            // 
            // btnFormVolumeRendering05
            // 
            this.btnFormVolumeRendering05.Location = new System.Drawing.Point(374, 457);
            this.btnFormVolumeRendering05.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormVolumeRendering05.Name = "btnFormVolumeRendering05";
            this.btnFormVolumeRendering05.Size = new System.Drawing.Size(346, 29);
            this.btnFormVolumeRendering05.TabIndex = 4;
            this.btnFormVolumeRendering05.Text = "FormVolumeRendering05-how-many-points";
            this.btnFormVolumeRendering05.UseVisualStyleBackColor = true;
            this.btnFormVolumeRendering05.Click += new System.EventHandler(this.btnFormVolumeRendering05_Click);
            // 
            // btnFromShaderDesigner1594
            // 
            this.btnFromShaderDesigner1594.Location = new System.Drawing.Point(374, 494);
            this.btnFromShaderDesigner1594.Margin = new System.Windows.Forms.Padding(4);
            this.btnFromShaderDesigner1594.Name = "btnFromShaderDesigner1594";
            this.btnFromShaderDesigner1594.Size = new System.Drawing.Size(346, 29);
            this.btnFromShaderDesigner1594.TabIndex = 4;
            this.btnFromShaderDesigner1594.Text = "FromShaderDesigner1.5.9.4";
            this.btnFromShaderDesigner1594.UseVisualStyleBackColor = true;
            this.btnFromShaderDesigner1594.Click += new System.EventHandler(this.btnFromShaderDesigner1594_Click);
            // 
            // btnFormDoubleTexture
            // 
            this.btnFormDoubleTexture.Location = new System.Drawing.Point(374, 531);
            this.btnFormDoubleTexture.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormDoubleTexture.Name = "btnFormDoubleTexture";
            this.btnFormDoubleTexture.Size = new System.Drawing.Size(346, 29);
            this.btnFormDoubleTexture.TabIndex = 4;
            this.btnFormDoubleTexture.Text = "FormDoubleTexture";
            this.btnFormDoubleTexture.UseVisualStyleBackColor = true;
            this.btnFormDoubleTexture.Click += new System.EventHandler(this.btnFormDoubleTexture_Click);
            // 
            // btnFormNormalLine
            // 
            this.btnFormNormalLine.Location = new System.Drawing.Point(374, 568);
            this.btnFormNormalLine.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormNormalLine.Name = "btnFormNormalLine";
            this.btnFormNormalLine.Size = new System.Drawing.Size(346, 29);
            this.btnFormNormalLine.TabIndex = 4;
            this.btnFormNormalLine.Text = "FormNormalLine";
            this.btnFormNormalLine.UseVisualStyleBackColor = true;
            this.btnFormNormalLine.Click += new System.EventHandler(this.btnFormNormalLine_Click);
            // 
            // btnFormSimpleRenderer
            // 
            this.btnFormSimpleRenderer.Location = new System.Drawing.Point(374, 605);
            this.btnFormSimpleRenderer.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormSimpleRenderer.Name = "btnFormSimpleRenderer";
            this.btnFormSimpleRenderer.Size = new System.Drawing.Size(346, 29);
            this.btnFormSimpleRenderer.TabIndex = 4;
            this.btnFormSimpleRenderer.Text = "FormSimpleRenderer";
            this.btnFormSimpleRenderer.UseVisualStyleBackColor = true;
            this.btnFormSimpleRenderer.Click += new System.EventHandler(this.btnFormSimpleRenderer_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 720);
            this.Controls.Add(this.btnFormWholeFontTextureElement);
            this.Controls.Add(this.btnTexImage2D);
            this.Controls.Add(this.btnCylinderElement);
            this.Controls.Add(this.btnSatelliteRotation);
            this.Controls.Add(this.btnCamera);
            this.Controls.Add(this.btnSimpleUICube);
            this.Controls.Add(this.btnFormPointSpriteStringElement);
            this.Controls.Add(this.btnFormMultipleHexahedrons2);
            this.Controls.Add(this.btnFormMultipleHexahedrons1);
            this.Controls.Add(this.btnFormMapBuffer);
            this.Controls.Add(this.btnFormInstancedRendering);
            this.Controls.Add(this.btnFormTransformFeedback);
            this.Controls.Add(this.btnFormScientificVisual3DControl);
            this.Controls.Add(this.btnFormColorCodedPicking);
            this.Controls.Add(this.btnFormSimpleRenderer);
            this.Controls.Add(this.btnFormNormalLine);
            this.Controls.Add(this.btnFormDoubleTexture);
            this.Controls.Add(this.btnFromShaderDesigner1594);
            this.Controls.Add(this.btnFormVolumeRendering05);
            this.Controls.Add(this.btnFormVolumeRendering04);
            this.Controls.Add(this.btnFormVolumeRendering_Hexahedron);
            this.Controls.Add(this.btnVR02_modernOpenGL_Points);
            this.Controls.Add(this.btnVR01_modernOpenGL_Quads);
            this.Controls.Add(this.btnFormVolumeRendering01);
            this.Controls.Add(this.btnFormLegacyTexture3D2);
            this.Controls.Add(this.btnFormLegacyTexture3D);
            this.Controls.Add(this.btnSimplePointSprite);
            this.Controls.Add(this.btnDebugging);
            this.Controls.Add(this.btnSimpleUIColorPalette);
            this.Controls.Add(this.btnSimpleUIAxis);
            this.Controls.Add(this.btnSimpleUIRect);
            this.Controls.Add(this.btnLegacySimpleUIRect);
            this.Controls.Add(this.btnTranslateOnScreen);
            this.Controls.Add(this.btnFormFontElement);
            this.Controls.Add(this.btnPyramidElement);
            this.Controls.Add(this.btnBasis);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormTest";
            this.Text = "测试窗口";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBasis;
        private System.Windows.Forms.Button btnCylinderElement;
        private System.Windows.Forms.Button btnFormFontElement;
        private System.Windows.Forms.Button btnPyramidElement;
        private System.Windows.Forms.Button btnCamera;
        private System.Windows.Forms.Button btnSatelliteRotation;
        private System.Windows.Forms.Button btnFormWholeFontTextureElement;
        private System.Windows.Forms.Button btnTranslateOnScreen;
        private System.Windows.Forms.Button btnLegacySimpleUIRect;
        private System.Windows.Forms.Button btnSimpleUIRect;
        private System.Windows.Forms.Button btnSimpleUIAxis;
        private System.Windows.Forms.Button btnSimpleUIColorPalette;
        private System.Windows.Forms.Button btnSimpleUICube;
        private System.Windows.Forms.Button btnDebugging;
        private System.Windows.Forms.Button btnSimplePointSprite;
        private System.Windows.Forms.Button btnFormPointSpriteStringElement;
        private System.Windows.Forms.Button btnFormLegacyTexture3D;
        private System.Windows.Forms.Button btnFormColorCodedPicking;
        private System.Windows.Forms.Button btnFormScientificVisual3DControl;
        private System.Windows.Forms.Button btnFormTransformFeedback;
        private System.Windows.Forms.Button btnFormInstancedRendering;
        private System.Windows.Forms.Button btnFormMapBuffer;
        private System.Windows.Forms.Button btnTexImage2D;
        private System.Windows.Forms.Button btnFormMultipleHexahedrons1;
        private System.Windows.Forms.Button btnFormMultipleHexahedrons2;
        private System.Windows.Forms.Button btnFormLegacyTexture3D2;
        private System.Windows.Forms.Button btnFormVolumeRendering01;
        private System.Windows.Forms.Button btnFormVolumeRendering_Hexahedron;
        private System.Windows.Forms.Button btnVR01_modernOpenGL_Quads;
        private System.Windows.Forms.Button btnVR02_modernOpenGL_Points;
        private System.Windows.Forms.Button btnFormVolumeRendering04;
        private System.Windows.Forms.Button btnFormVolumeRendering05;
        private System.Windows.Forms.Button btnFromShaderDesigner1594;
        private System.Windows.Forms.Button btnFormDoubleTexture;
        private System.Windows.Forms.Button btnFormNormalLine;
        private System.Windows.Forms.Button btnFormSimpleRenderer;
    }
}