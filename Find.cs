namespace ii_dinahyi_
{
    class Find
    {
        public static int FindX(int a, int b, double[,] A, int k)
        {
            int x = 0;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (A[j, i] == 0)
                    {
                        x = i;
                        k++;
                        break;
                    }
                }
                if (k != 0)
                    break;
            }
            return x;
        }

        public static int FindY(int a, int b, double[,] A, int k)
        {
            int y = 0;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (A[i, j] == 0)
                    {
                        y = i;
                        k++;
                        break;
                    }
                }
                if (k != 0)
                    break;
            }
            return y;
        }

        public static int FindXX(int a, int b, double[,] A, int k)
        {
            var xx = 0;
            for (int i = a; i >= 0; i--)
            {
                for (int j = b; j >= 0; j--)
                {
                    if (A[j, i] == 0)
                    {
                        xx = i;
                        k++;
                        break;
                    }
                }
                if (k != 0)
                {
                    k = 0;
                    break;
                }
            }
            return xx;
        }

        public static int FindYY(int a, int b, double[,] A, int k)
        {
            int yy = 0;
            for (int i = a; i >= 0; i--)
            {
                for (int j = b; j >= 0; j--)
                {
                    if (A[i, j] == 0)
                    {
                        yy = i;
                        k++;
                        break;
                    }
                }
                if (k != 0) break;
            }
            return yy;
        }
    }
}
