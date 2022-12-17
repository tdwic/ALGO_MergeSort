namespace MergeSort
{
    public class Program
    {
        public const int ARRAY_LENGTH = 30;
        static void Main(string[] args)
        {
            Console.WriteLine("Merge Sort");

            int[] inputArray = new int[ARRAY_LENGTH];

            for (int i = 0; i < ARRAY_LENGTH; i++)
            {
                Random random = new Random();
                inputArray[i] = random.Next(0, 99);
            }

            Console.WriteLine("Before:");
            PrintArray(inputArray);

            MergeSort(inputArray);

            Console.WriteLine("After:");
            PrintArray(inputArray);
        }

        private static void PrintArray(int[] inputArray)
        {
            Console.WriteLine("----------------------------------");

            for (int i = 0; i < inputArray.Length; i++)
            {
                Console.WriteLine(inputArray[i]);
            }

            Console.WriteLine("----------------------------------");
        }

        private static void MergeSort(int[] inputArray)
        {
            int inputArraySize = inputArray.Length;

            if (inputArraySize < 2)
            {
                return;
            }

            int midPoint = inputArraySize / 2;
            int leftSize = midPoint;
            int rightSize = ((inputArraySize - midPoint));

            int[] leftArray = new int[leftSize];
            int[] rightArray = new int[rightSize];

            for (int i = 0; i < midPoint; i++)
            {
                leftArray[i] = inputArray[i];
            }

            for (int j = midPoint; j < inputArraySize; j++)
            {
                rightArray[j - midPoint] = inputArray[j];
            }

            MergeSort(leftArray);
            MergeSort(rightArray);

            MergeSortFinal(inputArray, leftArray, rightArray);

        }

        private static void MergeSortFinal(int[] inputArray, int[] leftArray, int[] rightArray)
        {
            int leftCount = 0, rightCount = 0, mainCount = 0;
            int leftSize = leftArray.Length;
            int rightSize = rightArray.Length;

            while (leftCount < leftSize && rightCount < rightSize)
            {
                if (leftArray[leftCount] <= rightArray[rightCount])
                {
                    inputArray[mainCount] = leftArray[leftCount];
                    leftCount++;
                }
                else
                {
                    inputArray[mainCount] = rightArray[rightCount];
                    rightCount++;
                }
                mainCount++;
            }

            while (leftCount < leftSize)
            {
                inputArray[mainCount] = leftArray[leftCount];
                leftCount++;
                mainCount++;
            }

            while (rightCount < rightSize)
            {
                inputArray[mainCount] = rightArray[rightCount];
                rightCount++;
                mainCount++;
            }
        }
    }
}