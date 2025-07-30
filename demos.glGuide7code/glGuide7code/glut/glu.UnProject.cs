
using CSharpGL;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace demos.glGuide7code {
    internal static unsafe partial class glu {
        /// <summary>
        /// 将窗口坐标转换为世界坐标
        /// </summary>
        /// <param name="winX">窗口X坐标</param>
        /// <param name="winY">窗口Y坐标</param>
        /// <param name="winZ">窗口Z坐标（深度值）</param>
        /// <param name="modelMatrix">模型视图矩阵（16元素数组，按列主序存储）</param>
        /// <param name="projMatrix">投影矩阵（16元素数组，按列主序存储）</param>
        /// <param name="viewport">视口数组 [x, y, width, height]</param>
        /// <param name="objX">输出的世界坐标X</param>
        /// <param name="objY">输出的世界坐标Y</param>
        /// <param name="objZ">输出的世界坐标Z</param>
        /// <returns>成功返回true，失败返回false</returns>
        public static bool UnProject(
            double winX, double winY, double winZ,
            double* modelMatrix, double* projMatrix, int* viewport,
            out double objX, out double objY, out double objZ) {
            // 初始化输出参数
            objX = 0;
            objY = 0;
            objZ = 0;

            // 计算组合矩阵 (模型视图矩阵 * 投影矩阵)
            double[] finalMatrix = new double[16];
            MultiplyMatrix(modelMatrix, projMatrix, finalMatrix);

            // 计算逆矩阵
            double[] inverseMatrix = new double[16];
            if (!InvertMatrix(finalMatrix, inverseMatrix)) {
                return false;
            }

            // 将窗口坐标转换为规范化设备坐标(NDC)
            double x = (winX - viewport[0]) / viewport[2] * 2.0 - 1.0;
            double y = (winY - viewport[1]) / viewport[3] * 2.0 - 1.0;
            double z = 2.0 * winZ - 1.0;

            // 应用逆变换矩阵
            double[] inPts = { x, y, z, 1.0 };
            double[] outPts = new double[4];

            for (int i = 0; i < 4; i++) {
                outPts[i] = 0.0;
                for (int j = 0; j < 4; j++) {
                    outPts[i] += inverseMatrix[i + j * 4] * inPts[j];
                }
            }

            // 处理齐次坐标
            if (outPts[3] == 0.0) {
                return false;
            }

            // 计算最终的世界坐标
            objX = outPts[0] / outPts[3];
            objY = outPts[1] / outPts[3];
            objZ = outPts[2] / outPts[3];

            return true;
        }

        // 矩阵乘法辅助函数
        private static void MultiplyMatrix(double* a, double* b, double[] result) {
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    result[i * 4 + j] =
                        a[i * 4 + 0] * b[0 * 4 + j] +
                        a[i * 4 + 1] * b[1 * 4 + j] +
                        a[i * 4 + 2] * b[2 * 4 + j] +
                        a[i * 4 + 3] * b[3 * 4 + j];
                }
            }
        }

        // 矩阵求逆辅助函数 (使用伴随矩阵法)
        private static bool InvertMatrix(double[] m, double[] inverse) {
            double[] tmp = new double[16];
            double[] src = new double[16];
            double[] dst = new double[16];
            double det;

            // 复制源矩阵
            for (int i = 0; i < 16; i++) {
                src[i] = m[i];
            }

            // 构造单位矩阵
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    dst[i * 4 + j] = (i == j) ? 1.0 : 0.0;
                }
            }

            // 高斯消元法求逆
            for (int i = 0; i < 4; i++) {
                // 寻找主元
                int pivot = i;
                double pivotsize = src[i * 4 + i];

                if (pivotsize < 0)
                    pivotsize = -pivotsize;

                for (int j = i + 1; j < 4; j++) {
                    double tmpSize = src[j * 4 + i];
                    if (tmpSize < 0)
                        tmpSize = -tmpSize;

                    if (tmpSize > pivotsize) {
                        pivot = j;
                        pivotsize = tmpSize;
                    }
                }

                // 如果矩阵是奇异的，返回false
                if (pivotsize == 0)
                    return false;

                // 交换行
                if (pivot != i) {
                    for (int j = 0; j < 4; j++) {
                        double temp = src[i * 4 + j];
                        src[i * 4 + j] = src[pivot * 4 + j];
                        src[pivot * 4 + j] = temp;

                        temp = dst[i * 4 + j];
                        dst[i * 4 + j] = dst[pivot * 4 + j];
                        dst[pivot * 4 + j] = temp;
                    }
                }

                // 归一化当前行
                double f = src[i * 4 + i];
                for (int j = 0; j < 4; j++) {
                    src[i * 4 + j] /= f;
                    dst[i * 4 + j] /= f;
                }

                // 消元其他行
                for (int j = 0; j < 4; j++) {
                    if (j != i) {
                        double f2 = src[j * 4 + i];
                        for (int k = 0; k < 4; k++) {
                            src[j * 4 + k] -= f2 * src[i * 4 + k];
                            dst[j * 4 + k] -= f2 * dst[i * 4 + k];
                        }
                    }
                }
            }

            // 复制结果
            for (int i = 0; i < 16; i++) {
                inverse[i] = dst[i];
            }

            return true;
        }
    }
}