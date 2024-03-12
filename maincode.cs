   public static (int[], int, int) LoadBitmap(string filename)
    {
        using var image = Image.Load<Bgra32>(filename);
        int width = image.Width, height = image.Height;
        int[] result = new int[width * height];
        image.CopyPixelDataTo(MemoryMarshal.Cast<int, Bgra32>(result));//yes
        return (result, width, height);
    }

    unsafe public static void SaveBitmap(int[] data, int width, int height, string filename)
    {
        fixed (int* pData = data)
        {
            using var image = Image.WrapMemory<Bgra32>(pData, width, height);//hi
            image.SaveAsPng(filename);
        }
    }
}  protected double[] weights;
    double[] weightLogWeights, distribution;

    protected int[] sumsOfOnes;
    double sumOfWeights, sumOfWeightLogWeights, startingEntropy;
    protected double[] sumsOfWeights, sumsOfWeightLogWeights, entropies;

    public enum Heuristic { Entropy, MRV, Scanline };
    Heuristic heuristic;
