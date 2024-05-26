using System;

public class Program
{
  
    public static int MinFolders(int cssFiles, int jsFiles, int readMeFiles, int capacity)
    {
        int totalFiles = cssFiles + jsFiles + readMeFiles;
        if (totalFiles == 0)
            return 0;

        if (readMeFiles == totalFiles)
            return readMeFiles;

        int minimumNewFoldersCount = 0;
        bool cssTurn = cssFiles > jsFiles;
        bool readMeFileAllocated = false;
        while (cssFiles > 0 || jsFiles > 0 || readMeFiles > 0)
        {
            minimumNewFoldersCount++;
            int newFolderCapacity = 0;
            if (readMeFiles > 0 && !readMeFileAllocated)
            {
                readMeFiles--;
                newFolderCapacity++;
            }
            while (capacity > newFolderCapacity)
            {
                if (cssFiles > 0 && cssTurn)
                {
                    cssFiles--;
                    newFolderCapacity++;
                    cssTurn = false;
                    continue;
                }
                else if (jsFiles > 0 && !cssTurn)
                {
                    jsFiles--;
                    newFolderCapacity++;
                    cssTurn = true;
                    continue;
                }
                break;
            }
            cssTurn = cssFiles > jsFiles;
            readMeFileAllocated = false;
        }
        return minimumNewFoldersCount;
    }

    public static void Main(string[] args)
    {
        // Sample Input
        int cssFiles = 1500;
        int jsFiles = 356;
        int readMeFiles = 750;
        int capacity = 80;

        int result = MinFolders(cssFiles, jsFiles, readMeFiles, capacity);
        Console.WriteLine(result); // Output should be 5
    }
}
