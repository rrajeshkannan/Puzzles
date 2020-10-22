using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace MostBalancedPartition
{
    class TreeBasedLogic
    {
        internal class Directory
        {
            public int Id { get; set; }

            public int FilesSize { get; set; }

            public Directory Parent { get; set; }

            public List<Directory> SubDirectories { get; }

            public Directory(int id, int filesSize)
            {
                Id = id;
                FilesSize = filesSize;
                Parent = null;
                SubDirectories = new List<Directory>();
                //SubDirectorySize = 0;
            }

            public int CalculateHierarchySizeInclusive()
            {
                int hierarchySize = 0;

                foreach (var subDirectory in SubDirectories)
                {
                    hierarchySize += subDirectory.CalculateHierarchySizeInclusive();
                }

                return hierarchySize + FilesSize;
            }

            public void AddChild(Directory child)
            {
                SubDirectories.Add(child);
                child.Parent = this;
            }
        }

        internal static List<Directory> PrepareTreeStructure(List<int> parent, List<int> files_size)
        {
            var directories = new List<Directory>();

            for (int i = 0; i < parent.Count; i++)
            {
                directories.Add(new Directory(i, files_size[i]));
            }

            for (int i = 0; i < parent.Count; i++)
            {
                if (parent[i] != -1)
                {
                    // Non-root folder
                    var parentDirectory = directories[parent[i]];

                    parentDirectory.AddChild(directories[i]);
                }
            }

            return directories;
        }

        internal static void RecursiveMeasureSubPartitions(Directory directory, int fullPartitionSize,
            ref int difference, ref Directory partitionAt)
        {
            foreach (var subDirectory in directory.SubDirectories)
            {
                RecursiveMeasureSubPartitions(subDirectory, fullPartitionSize, ref difference, ref partitionAt);
            }

            if (directory.Parent == null)
            {
                return;
            }

            var subPartitionSize1 = directory.CalculateHierarchySizeInclusive();
            var subPartitionSize2 = fullPartitionSize - subPartitionSize1;
            var partitionDifference = Math.Abs(subPartitionSize1 - subPartitionSize2);

            if (partitionDifference < difference)
            {
                difference = partitionDifference;
                partitionAt = directory;
            }
        }

        public static int mostBalancedPartition(List<int> parent, List<int> files_size, out int difference, out int partitionAt)
        {
            var directories = PrepareTreeStructure(parent, files_size);

            var rootDirectory = directories[0];
            var partitionDifference = Int32.MaxValue;
            Directory partitionDirectory = null;

            var fullPartitionSize = rootDirectory.CalculateHierarchySizeInclusive();

            RecursiveMeasureSubPartitions(rootDirectory, fullPartitionSize, ref partitionDifference, ref partitionDirectory);

            difference = partitionDifference;
            partitionAt = partitionDirectory.Id;

            return 0;
        }
    }

    class ArrayBasedLogic
    {
        private static int[] PopulateTreeStructure(List<int> parent, List<int> files_size)
        {
            var hierarchySizesInclusive = new int[parent.Count];

            for (int i = 0; i < parent.Count; i++)
            {
                hierarchySizesInclusive[i] = files_size[i];
            }

            // i = 0, means root folder, means parent[i] = -1 ==> so, skip it and start from 1
            // for loop only for non-root folders
            for (int i = 1; i < parent.Count; i++)
            {
                IncrementAllParentSizesRecursiveUpUntilRoot(files_size[i], i, parent, files_size, hierarchySizesInclusive);
            }

            return hierarchySizesInclusive;
        }

        private static void IncrementAllParentSizesRecursiveUpUntilRoot(
            int incrementBy, int directoryId, List<int> parent, List<int> files_size, int[] hierarchySizesInclusive)
        {
            int parentId = parent[directoryId];

            if (parentId != -1)
            {
                hierarchySizesInclusive[parentId] += incrementBy;
                IncrementAllParentSizesRecursiveUpUntilRoot(incrementBy, parentId, parent, files_size, hierarchySizesInclusive);
            }
        }

        private static void RecursiveMeasureSubPartitions(int[] hierarchySizesInclusive, ref int difference, ref int partitionAt)
        {
            int fullPartitionSize = hierarchySizesInclusive[0];

            // we need to find two partitions which as balanced as possible
            // root folder not required to be considered, because the whole tree is already a single partition
            for (int i = 1; i < hierarchySizesInclusive.Length; i++)
            {
                var subPartitionSize1 = hierarchySizesInclusive[i];
                var subPartitionSize2 = fullPartitionSize - subPartitionSize1;
                var partitionDifference = Math.Abs(subPartitionSize1 - subPartitionSize2);

                if (partitionDifference < difference)
                {
                    difference = partitionDifference;
                    partitionAt = i;
                }
            }
        }

        public static int mostBalancedPartition(List<int> parent, List<int> files_size, out int difference, out int partitionAt)
        {
            var hierarchySizesInclusive = PopulateTreeStructure(parent, files_size);

            difference = Int32.MaxValue;
            partitionAt = -1;

            RecursiveMeasureSubPartitions(hierarchySizesInclusive, ref difference, ref partitionAt);

            return 0;
        }
    }

    class Result
    {
        public static void mostBalancedPartition(List<int> parent, List<int> files_size, out int difference, out int partitionAt)
        {
            //TreeBasedLogic.mostBalancedPartition(parent, files_size, out difference, out partitionAt);
            ArrayBasedLogic.mostBalancedPartition(parent, files_size, out difference, out partitionAt);
        }
    }

    class Program
    {
        class Solution
        {
            public static void Main(string[] args)
            {
                // Test-case-1.1:
                //List<int> parent = new List<int>() { -1, 0, 0, 1, 1, 2 };
                //List<int> files_size = new List<int>() { 10, 20, 20, 10, 10, 10 };

                // Test-case-1.2:
                //List<int> parent = new List<int>() { -1, 0, 0, 1, 1, 2 };
                //List<int> files_size = new List<int>() { 10, 10, 10, 20, 10, 10 };

                // Test-case-2:
                List<int> parent = new List<int>() { -1, 0, 1, 2 };
                List<int> files_size = new List<int>() { 1, 4, 3, 4 };

                // Test-case-3.1:
                //List<int> parent = new List<int>() { -1, 0, 0, 0 };
                //List<int> files_size = new List<int>() { 10, 11, 10, 10 };

                // Test-case-3.2:
                //List<int> parent = new List<int>() { -1, 0, 0, 0 };
                //List<int> files_size = new List<int>() { 10, 10, 11, 10 };

                Result.mostBalancedPartition(parent, files_size, out int difference, out int partitionAt);

                Console.WriteLine("Difference: {0} PartitionAt: {1}", difference, partitionAt);
                Console.ReadKey();
            }
        }
    }
}