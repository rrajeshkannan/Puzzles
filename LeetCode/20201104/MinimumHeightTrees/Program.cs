using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumHeightTrees
{
    // https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3519/

    // A tree is an undirected graph in which any two vertices are connected by exactly one path. 
    // In other words, any connected graph without simple cycles is a tree.
    // 
    // Given a tree of 
    //   n nodes labelled from 0 to n - 1, 
    //   and an array of n - 1 edges 
    //   where edges[i] = [ai, bi] indicates that there is an undirected edge between the two nodes ai and bi in the tree, 
    //   you can choose any node of the tree as the root. 
    // When you select a node x as the root, the result tree has height h. 
    // Among all possible rooted trees, those with minimum height (i.e. min(h)) are called minimum height trees (MHTs).
    // 
    // Return a list of all MHTs' root labels. You can return the answer in any order.
    // 
    // The height of a rooted tree is the number of edges on the longest downward path between the root and a leaf.

    public class TreeNode
    {
        public int Label { get; set; }
        public List<TreeNode> Edges { get; set; }

        public TreeNode(int label)
        {
            this.Label = label;
            this.Edges = new List<TreeNode>();
        }

        public override string ToString()
        {
            return this.Label.ToString();

            //StringBuilder text = new StringBuilder();

            //foreach (var edge in Edges)
            //{
            //    text.Append(String.Format("{0}->{1} | ", this.Label, edge.Label));
            //}

            //return text.ToString();
        }

        public int Depth(int terminalDepth, ref bool interimTermination)
        {
            return Depth(new HashSet<int>() { this.Label }, terminalDepth, ref interimTermination);
        }

        public int Depth(HashSet<int> visited, int terminalDepth, ref bool interimTermination)
        {
            if (!this.Edges.Any())
            {
                return 0;
            }

            var maxDepth = 0;

            foreach (var child in this.Edges)
            {
                if (visited.Contains(child.Label))
                {
                    // edges are undirected and tree is acyclic -> so, the target node can only be such that it is already visited
                    // no need to continue treading this path further
                    continue;
                }

                visited.Add(child.Label);

                var depthOfSubtree = child.Depth(visited, terminalDepth, ref interimTermination);

                // The height of a rooted tree is the number of edges on the longest downward path between the root and a leaf.
                if (maxDepth < depthOfSubtree)
                {
                    maxDepth = depthOfSubtree;
                }

                if (maxDepth > terminalDepth)
                {
                    // at least one child path is going beyond allowed terminalDepth
                    // so, no need to consider the tree with this "root" further in the race
                    interimTermination = true;
                }

                if (interimTermination)
                {
                    break;
                }
            }

            // +1 - for this node
            return maxDepth + 1;
        }
    }

    public class Solution
    {
        public IEnumerable<TreeNode> FormulateTree(int n, int[][] edges)
        {
            var tree = new TreeNode[n];

            for (int i = 0; i < n; i++)
            {
                tree[i] = new TreeNode(i);
            }

            for (int i = 0; i < edges.Length; i++)
            {
                if (!edges[i].Any())
                {
                    continue;
                }

                var left = edges[i][0];
                var right = edges[i][1];

                var leftNode = tree[left];
                var rightNode = tree[right];

                leftNode.Edges.Add(rightNode);
                rightNode.Edges.Add(leftNode);
            }

            return tree;

            //var maxChildren = tree
            //    .Max(treeNode => treeNode.Edges.Count);

            //// Consider only the tree-node with many edges, because, it would contribute to the minimum height tree
            //return tree
            //    .Where(treeNode => maxChildren == treeNode.Edges.Count);
        }

        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            // 1. Formulate tree
            var tree = FormulateTree(n, edges);

            var minimumHeightTreeRoots = new List<int>();
            var minimumHeight = Int32.MaxValue;

            // 2. Assume a node as root node and measure the height of tree
            // 3. Continue with every other node
            foreach (var root in tree)
            {
                bool interimTermination = false;
                var depth = root.Depth(minimumHeight, ref interimTermination);

                // if (interimTermination) - no need to consider the tree with this root as it is anyway, a taller tree
                if (!interimTermination)
                {
                    if (minimumHeight == depth)
                    {
                        // another tree with same minimum height -> add it
                        minimumHeightTreeRoots.Add(root.Label);
                    }
                    else if (minimumHeight > depth)
                    {
                        // found a new minimum height -> discard already found lists and start considering new ones
                        minimumHeight = depth;
                        minimumHeightTreeRoots = new List<int> { root.Label };
                    }
                }
            }

            return minimumHeightTreeRoots;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var edges1 = new int[][]
            {
                new int[] {1, 0},
                new int[] {1, 2},
                new int[] {1, 3},
            };
            var result1 = solution.FindMinHeightTrees(4, edges1);

            var edges2 = new int[][]
            {
                new int[] {3,0},
                new int[] {3,1},
                new int[] {3,2},
                new int[] {3,4},
                new int[] {5,4},
            };
            var result2 = solution.FindMinHeightTrees(6, edges2);

            var edges3 = new int[][]
            {
                new int[]{},
            };
            var result3 = solution.FindMinHeightTrees(1, edges3);

            var edges4 = new int[][]
            {
                new int[]{0, 1},
            };
            var result4 = solution.FindMinHeightTrees(2, edges4);

            var edges5 = new int[][]
            {
                new int[] {0,1}, new int[] {0,2},new int[] {0,3},new int[] {1,4},new int[] {2,5},new int[] {1,6},new int[] {2,7},new int[] {7,8},new int[] {5,9},
                new int[] {9,10},new int[] {0,11},new int[] {8,12},new int[] {12,13},new int[] {3,14},new int[] {11,15},new int[] {8,16},new int[] {6,17},
                new int[] {10,18},new int[] {12,19},new int[] {5,20},new int[] {1,21},new int[] {21,22},new int[] {11,23},new int[] {2,24},new int[] {15,25},
                new int[] {6,26},new int[] {14,27},new int[] {13,28},new int[] {7,29},new int[] {16,30},new int[] {10,31},new int[] {8,32},new int[] {13,33},
                new int[] {22,34},new int[] {16,35},new int[] {34,36},new int[] {21,37},new int[] {19,38},new int[] {4,39},new int[] {34,40},new int[] {25,41},
                new int[] {8,42},new int[] {39,43},new int[] {21,44},new int[] {20,45},new int[] {1,46},new int[] {25,47},new int[] {33,48},new int[] {41,49},
                new int[] {26,50},new int[] {18,51},new int[] {1,52},new int[] {15,53},new int[] {11,54},new int[] {43,55},new int[] {9,56},new int[] {45,57},
                new int[] {21,58},new int[] {41,59},new int[] {40,60},new int[] {55,61},new int[] {58,62},new int[] {37,63},new int[] {34,64},new int[] {42,65},
                new int[] {47,66},new int[] {22,67},new int[] {18,68},new int[] {2,69},new int[] {20,70},new int[] {23,71},new int[] {36,72},new int[] {66,73},
                new int[] {62,74},new int[] {49,75},new int[] {67,76},new int[] {54,77},new int[] {58,78},new int[] {27,79},new int[] {39,80},new int[] {33,81},
                new int[] {71,82},new int[] {80,83},new int[] {21,84},new int[] {42,85},new int[] {1,86},new int[] {66,87},new int[] {71,88},new int[] {8,89},
                new int[] {23,90},new int[] {55,91},new int[] {47,92},new int[] {52,93},new int[] {43,94},new int[] {18,95},new int[] {11,96},new int[] {32,97},
                new int[] {11,98},new int[] {10,99},new int[] {10,100},new int[] {36,101},new int[] {67,102},new int[] {4,103},new int[] {72,104},new int[] {89,105},
                new int[] {82,106},new int[] {39,107},new int[] {59,108},new int[] {90,109},new int[] {89,110},new int[] {71,111},new int[] {38,112},new int[] {14,113},
                new int[] {65,114},new int[] {30,115},new int[] {99,116},new int[] {76,117},new int[] {110,118},new int[] {30,119},new int[] {9,120},new int[] {112,121},
                new int[] {87,122},new int[] {40,123},new int[] {94,124},new int[] {124,125},new int[] {72,126},new int[] {35,127},new int[] {45,128},new int[] {24,129},
                new int[] {73,130},new int[] {60,131},new int[] {60,132},new int[] {126,133},new int[] {100,134},new int[] {113,135},new int[] {65,136},new int[] {30,137},
                new int[] {78,138},new int[] {18,139},new int[] {34,140},new int[] {77,141},new int[] {41,142},new int[] {34,143},new int[] {53,144},new int[] {10,145},
                new int[] {94,146},new int[] {66,147},new int[] {101,148},new int[] {96,149},new int[] {11,150},new int[] {70,151},new int[] {51,152},new int[] {110,153},
                new int[] {37,154},new int[] {69,155},new int[] {109,156},new int[] {72,157},new int[] {112,158},new int[] {84,159},new int[] {32,160},new int[] {82,161},
                new int[] {36,162},new int[] {107,163},new int[] {99,164},new int[] {129,165},new int[] {115,166},new int[] {95,167},new int[] {76,168},new int[] {2,169},
                new int[] {140,170},new int[] {99,171},new int[] {146,172},new int[] {47,173},new int[] {20,174},new int[] {135,175},new int[] {69,176},new int[] {53,177},
                new int[] {97,178},new int[] {43,179},new int[] {102,180},new int[] {83,181},new int[] {8,182},new int[] {138,183},new int[] {120,184},new int[] {8,185},
                new int[] {89,186},new int[] {120,187},new int[] {24,188},new int[] {2,189},new int[] {87,190},new int[] {99,191},new int[] {176,192},new int[] {60,193},
                new int[] {58,194},new int[] {20,195},new int[] {10,196},new int[] {81,197},new int[] {159,198},new int[] {37,199},new int[] {180,200},new int[] {12,201},
                new int[] {145,202},new int[] {132,203},new int[] {5,204},new int[] {95,205},new int[] {80,206},new int[] {4,207},new int[] {125,208},new int[] {104,209},
                new int[] {32,210},new int[] {145,211},new int[] {41,212},new int[] {106,213},new int[] {113,214},new int[] {143,215},new int[] {76,216},new int[] {115,217},
                new int[] {66,218},new int[] {218,219},new int[] {39,220},new int[] {98,221},new int[] {32,222},new int[] {41,223},new int[] {136,224},new int[] {38,225},
                new int[] {49,226},new int[] {32,227},new int[] {107,228},new int[] {109,229},new int[] {77,230},new int[] {130,231},new int[] {94,232},new int[] {122,233},
                new int[] {201,234},new int[] {111,235},new int[] {85,236},new int[] {178,237},new int[] {220,238},new int[] {1,239},new int[] {127,240},new int[] {29,241},
                new int[] {193,242},new int[] {94,243},new int[] {120,244},new int[] {81,245},new int[] {9,246},new int[] {28,247},new int[] {93,248},new int[] {228,249},
                new int[] {133,250},new int[] {243,251},new int[] {26,252},new int[] {90,253},new int[] {194,254},new int[] {63,255},new int[] {170,256},new int[] {243,257},
                new int[] {26,258},new int[] {17,259},new int[] {41,260},new int[] {205,261},new int[] {181,262},new int[] {33,263},new int[] {213,264},new int[] {150,265},
                new int[] {152,266},new int[] {212,267},new int[] {56,268},new int[] {150,269},new int[] {153,270},new int[] {258,271},new int[] {47,272},new int[] {66,273},
                new int[] {23,274},new int[] {12,275},new int[] {82,276},new int[] {120,277},new int[] {35,278},new int[] {238,279},new int[] {44,280},new int[] {178,281},
                new int[] {158,282},new int[] {120,283},new int[] {181,284},new int[] {180,285},new int[] {283,286},new int[] {121,287},new int[] {34,288},new int[] {244,289},
                new int[] {143,290},new int[] {49,291},new int[] {267,292},new int[] {193,293},new int[] {162,294},new int[] {158,295},new int[] {166,296},new int[] {202,297},
                new int[] {57,298},new int[] {30,299},new int[] {225,300},new int[] {248,301},new int[] {199,302},new int[] {185,303},new int[] {194,304},new int[] {241,305},
                new int[] {147,306},new int[] {219,307},new int[] {150,308},new int[] {118,309},new int[] {125,310},new int[] {124,311},new int[] {47,312},new int[] {65,313},
                new int[] {255,314},new int[] {204,315},new int[] {196,316},new int[] {121,317},new int[] {277,318},new int[] {250,319},new int[] {299,320},new int[] {320,321},
                new int[] {49,322},new int[] {27,323},new int[] {115,324},new int[] {151,325},new int[] {17,326},new int[] {5,327},new int[] {77,328},new int[] {228,329},
                new int[] {297,330},new int[] {169,331},new int[] {147,332},new int[] {163,333},new int[] {158,334},new int[] {96,335},new int[] {155,336},new int[] {333,337},
                new int[] {137,338},new int[] {336,339},new int[] {30,340},new int[] {189,341},new int[] {169,342},new int[] {247,343},new int[] {274,344},new int[] {132,345},
                new int[] {15,346},new int[] {232,347},new int[] {51,348},new int[] {79,349},new int[] {141,350},new int[] {125,351},new int[] {174,352},new int[] {221,353},
                new int[] {62,354},new int[] {100,355},new int[] {336,356},new int[] {196,357},new int[] {332,358},new int[] {294,359},new int[] {324,360},new int[] {64,361},
                new int[] {196,362},new int[] {226,363},new int[] {12,364},new int[] {55,365},new int[] {19,366},new int[] {8,367},new int[] {143,368},new int[] {35,369},
                new int[] {63,370},new int[] {101,371},new int[] {129,372},new int[] {70,373},new int[] {82,374},new int[] {188,375},new int[] {328,376},new int[] {237,377},
                new int[] {304,378},new int[] {167,379},new int[] {6,380},new int[] {205,381},new int[] {316,382},new int[] {46,383},new int[] {76,384},new int[] {331,385},
                new int[] {382,386},new int[] {348,387},new int[] {250,388},new int[] {93,389},new int[] {35,390},new int[] {66,391},new int[] {82,392},new int[] {166,393},
                new int[] {264,394},new int[] {132,395},new int[] {315,396},new int[] {81,397},new int[] {239,398},new int[] {160,399},new int[] {306,400},new int[] {341,401},
                new int[] {265,402},new int[] {123,403},new int[] {243,404},new int[] {232,405},new int[] {139,406},new int[] {203,407},new int[] {14,408},new int[] {134,409},
                new int[] {402,410},new int[] {38,411},new int[] {146,412},new int[] {316,413},new int[] {276,414},new int[] {174,415},new int[] {204,416},new int[] {332,417},
                new int[] {182,418},new int[] {77,419},new int[] {165,420},new int[] {58,421},new int[] {349,422},new int[] {312,423},new int[] {121,424},new int[] {128,425},
                new int[] {276,426},new int[] {373,427},new int[] {383,428},new int[] {249,429},new int[] {39,430},new int[] {255,431},new int[] {231,432},new int[] {167,433},
                new int[] {418,434},new int[] {232,435},new int[] {316,436},new int[] {82,437},new int[] {216,438},new int[] {83,439},new int[] {31,440},new int[] {312,441},
                new int[] {76,442},new int[] {73,443},new int[] {169,444},new int[] {298,445},new int[] {224,446},new int[] {80,447},new int[] {111,448},new int[] {270,449},
                new int[] {350,450},new int[] {349,451},new int[] {256,452},new int[] {258,453},new int[] {75,454},new int[] {373,455},new int[] {430,456},new int[] {14,457},
                new int[] {209,458},new int[] {280,459},new int[] {110,460},new int[] {162,461},new int[] {431,462},new int[] {372,463},new int[] {146,464},new int[] {240,465},
                new int[] {27,466},new int[] {123,467},new int[] {324,468},new int[] {69,469},new int[] {28,470},new int[] {327,471},new int[] {384,472},new int[] {426,473},
                new int[] {25,474},new int[] {351,475},new int[] {252,476},new int[] {432,477},new int[] {86,478},new int[] {442,479},new int[] {92,480},new int[] {99,481},
                new int[] {213,482},new int[] {64,483},new int[] {97,484},new int[] {410,485},new int[] {273,486},new int[] {456,487},new int[] {156,488},new int[] {32,489},
                new int[] {154,490},new int[] {330,491},new int[] {115,492},new int[] {311,493},new int[] {87,494},new int[] {368,495},new int[] {264,496},new int[] {322,497},
                new int[] {152,498},new int[] {253,499},new int[] {106,500},new int[] {454,501},new int[] {356,502},new int[] {77,503},new int[] {452,504},new int[] {25,505},
                new int[] {61,506},new int[] {260,507},new int[] {395,508},new int[] {251,509},new int[] {45,510},new int[] {180,511},new int[] {78,512},new int[] {316,513},
                new int[] {294,514},new int[] {491,515},new int[] {191,516},new int[] {130,517},new int[] {9,518},new int[] {283,519},new int[] {95,520},new int[] {203,521},
                new int[] {514,522},new int[] {312,523},new int[] {18,524},new int[] {306,525},new int[] {343,526},new int[] {368,527},new int[] {45,528},new int[] {192,529},
                new int[] {217,530},new int[] {241,531},new int[] {224,532},new int[] {203,533},new int[] {118,534},new int[] {445,535},new int[] {264,536},new int[] {415,537},
                new int[] {0,538},new int[] {20,539},new int[] {427,540},new int[] {468,541},new int[] {346,542},new int[] {53,543},new int[] {318,544},new int[] {241,545},
                new int[] {367,546},new int[] {461,547},new int[] {22,548},new int[] {47,549},new int[] {526,550},new int[] {438,551},new int[] {260,552},new int[] {352,553},
                new int[] {328,554},new int[] {197,555},new int[] {359,556},new int[] {482,557},new int[] {457,558},new int[] {51,559},new int[] {244,560},new int[] {401,561},
                new int[] {89,562},new int[] {341,563},new int[] {305,564},new int[] {499,565},new int[] {194,566},new int[] {223,567},new int[] {248,568},new int[] {197,569},
                new int[] {285,570},new int[] {495,571},new int[] {298,572},new int[] {535,573},new int[] {79,574},new int[] {6,575},new int[] {188,576},new int[] {48,577},
                new int[] {394,578},new int[] {136,579},new int[] {150,580},new int[] {328,581},new int[] {207,582},new int[] {527,583},new int[] {415,584},new int[] {429,585},
                new int[] {44,586},new int[] {154,587},new int[] {166,588},new int[] {6,589},new int[] {529,590},new int[] {103,591},new int[] {434,592},new int[] {104,593},
                new int[] {239,594},new int[] {226,595},new int[] {349,596},new int[] {394,597},new int[] {457,598},new int[] {491,599},new int[] {351,600},new int[] {102,601},
                new int[] {152,602},new int[] {183,603},new int[] {30,604},new int[] {177,605},new int[] {288,606},new int[] {140,607},new int[] {146,608},new int[] {373,609},
                new int[] {553,610},new int[] {595,611},new int[] {359,612},new int[] {566,613},new int[] {123,614},new int[] {270,615},new int[] {395,616},new int[] {2,617},
                new int[] {414,618},new int[] {418,619},new int[] {447,620},new int[] {289,621},new int[] {42,622},new int[] {614,623},new int[] {106,624},new int[] {421,625},
                new int[] {197,626},new int[] {247,627},new int[] {437,628},new int[] {371,629},new int[] {82,630},new int[] {573,631},new int[] {393,632},new int[] {345,633},
                new int[] {283,634},new int[] {599,635},new int[] {469,636},new int[] {574,637},new int[] {248,638},new int[] {292,639},new int[] {165,640},new int[] {125,641},
                new int[] {563,642},new int[] {336,643},new int[] {473,644},new int[] {390,645},new int[] {356,646},new int[] {166,647},new int[] {229,648},new int[] {209,649},
                new int[] {510,650},new int[] {452,651},new int[] {469,652},new int[] {433,653},new int[] {48,654},new int[] {47,655},new int[] {625,656},new int[] {395,657},
                new int[] {117,658},new int[] {418,659},new int[] {367,660},new int[] {73,661},new int[] {368,662},new int[] {232,663},new int[] {651,664},new int[] {292,665},
                new int[] {603,666},new int[] {436,667},new int[] {552,668},new int[] {123,669},new int[] {528,670},new int[] {661,671},new int[] {121,672},new int[] {307,673},
                new int[] {315,674},new int[] {453,675},new int[] {29,676},new int[] {134,677},new int[] {406,678},new int[] {655,679},new int[] {160,680},new int[] {462,681},
                new int[] {318,682},new int[] {27,683},new int[] {326,684},new int[] {391,685},new int[] {106,686},new int[] {406,687},new int[] {650,688},new int[] {510,689},
                new int[] {347,690},new int[] {497,691},new int[] {292,692},new int[] {185,693},new int[] {259,694},new int[] {472,695},new int[] {177,696},new int[] {666,697},
                new int[] {391,698},new int[] {195,699},new int[] {424,700},new int[] {57,701},new int[] {286,702},new int[] {93,703},new int[] {17,704},new int[] {1,705},
                new int[] {427,706},new int[] {467,707},new int[] {545,708},new int[] {130,709},new int[] {254,710},new int[] {559,711},new int[] {465,712},new int[] {155,713},
                new int[] {540,714},new int[] {308,715},new int[] {646,716},new int[] {96,717},new int[] {117,718},new int[] {485,719},new int[] {618,720},new int[] {31,721},
                new int[] {26,722},new int[] {495,723},new int[] {28,724},new int[] {443,725},new int[] {621,726},new int[] {33,727},new int[] {118,728},new int[] {83,729},
                new int[] {255,730},new int[] {567,731},new int[] {232,732},new int[] {39,733},new int[] {501,734},new int[] {220,735},new int[] {81,736},new int[] {424,737},
                new int[] {383,738},new int[] {630,739},new int[] {246,740},new int[] {118,741},new int[] {145,742},new int[] {683,743},new int[] {611,744},new int[] {653,745},
                new int[] {294,746},new int[] {99,747},new int[] {747,748},new int[] {416,749},new int[] {719,750},new int[] {43,751},new int[] {388,752},new int[] {212,753},
                new int[] {165,754},new int[] {565,755},new int[] {191,756},new int[] {70,757},new int[] {151,758},new int[] {554,759},new int[] {414,760},new int[] {350,761},
                new int[] {415,762},new int[] {33,763},new int[] {39,764},new int[] {429,765},new int[] {723,766},new int[] {647,767},new int[] {543,768},new int[] {661,769},
                new int[] {61,770},new int[] {629,771},new int[] {48,772},new int[] {677,773},new int[] {58,774},new int[] {314,775},new int[] {211,776},new int[] {597,777},
                new int[] {761,778},new int[] {485,779},new int[] {2,780},new int[] {656,781},new int[] {360,782},new int[] {64,783},new int[] {381,784},new int[] {226,785},
                new int[] {340,786},new int[] {545,787},new int[] {697,788},new int[] {607,789},new int[] {301,790},new int[] {756,791},new int[] {582,792},new int[] {111,793},
                new int[] {724,794},new int[] {631,795},new int[] {423,796},new int[] {272,797},new int[] {45,798},new int[] {519,799},new int[] {444,800},new int[] {650,801},
                new int[] {236,802},new int[] {462,803},new int[] {531,804},new int[] {640,805},new int[] {433,806},new int[] {325,807},new int[] {293,808},new int[] {32,809},
                new int[] {19,810},new int[] {104,811},new int[] {655,812},new int[] {206,813},new int[] {615,814},new int[] {738,815},new int[] {520,816},new int[] {749,817},
                new int[] {811,818},new int[] {229,819},new int[] {175,820},new int[] {172,821},new int[] {810,822},new int[] {502,823},new int[] {458,824},new int[] {235,825},
                new int[] {660,826},new int[] {708,827},new int[] {422,828},new int[] {329,829},new int[] {570,830},new int[] {157,831},new int[] {430,832},new int[] {529,833},
                new int[] {19,834},new int[] {88,835},new int[] {168,836},new int[] {703,837},new int[] {474,838},new int[] {598,839},new int[] {124,840},new int[] {356,841},
                new int[] {608,842},new int[] {499,843},new int[] {678,844},new int[] {674,845},new int[] {791,846},new int[] {183,847},new int[] {762,848},new int[] {373,849},
                new int[] {613,850},new int[] {505,851},new int[] {379,852},new int[] {541,853},new int[] {737,854},new int[] {792,855},new int[] {397,856},new int[] {383,857},
                new int[] {450,858},new int[] {224,859},new int[] {310,860},new int[] {815,861},new int[] {420,862},new int[] {244,863},new int[] {409,864},new int[] {505,865},
                new int[] {520,866},new int[] {245,867},new int[] {437,868},new int[] {763,869},new int[] {686,870},new int[] {849,871},new int[] {740,872},new int[] {252,873},
                new int[] {501,874},new int[] {2,875},new int[] {171,876},new int[] {79,877},new int[] {233,878},new int[] {849,879},new int[] {823,880},new int[] {323,881},
                new int[] {661,882},new int[] {516,883},new int[] {6,884},new int[] {4,885},new int[] {176,886},new int[] {741,887},new int[] {284,888},new int[] {62,889},
                new int[] {667,890},new int[] {652,891},new int[] {842,892},new int[] {363,893},new int[] {243,894},new int[] {359,895},new int[] {288,896},new int[] {640,897},
                new int[] {540,898},new int[] {40,899},new int[] {27,900},new int[] {591,901},new int[] {368,902},new int[] {42,903},new int[] {738,904},new int[] {185,905},
                new int[] {705,906},new int[] {120,907},new int[] {310,908},new int[] {464,909},new int[] {681,910},new int[] {236,911},new int[] {530,912},new int[] {300,913},
                new int[] {361,914},new int[] {95,915},new int[] {53,916},new int[] {683,917},new int[] {720,918},new int[] {796,919},new int[] {506,920},new int[] {425,921},
                new int[] {772,922},new int[] {510,923},new int[] {149,924},new int[] {406,925},new int[] {510,926},new int[] {175,927},new int[] {456,928},new int[] {750,929},
                new int[] {633,930},new int[] {848,931},new int[] {459,932},new int[] {504,933},new int[] {404,934},new int[] {702,935},new int[] {818,936},new int[] {138,937},
                new int[] {572,938},new int[] {778,939},new int[] {576,940},new int[] {330,941},new int[] {547,942},new int[] {524,943},new int[] {31,944},new int[] {136,945},
                new int[] {633,946},new int[] {905,947},new int[] {738,948},new int[] {792,949},new int[] {772,950},new int[] {626,951},new int[] {28,952},new int[] {528,953},
                new int[] {656,954},new int[] {148,955},new int[] {705,956},new int[] {100,957},new int[] {6,958},new int[] {631,959},new int[] {340,960},new int[] {883,961},
                new int[] {887,962},new int[] {288,963},new int[] {263,964},new int[] {952,965},new int[] {306,966},new int[] {130,967},new int[] {615,968},new int[] {919,969},
                new int[] {896,970},new int[] {330,971},new int[] {259,972},new int[] {111,973},new int[] {866,974},new int[] {562,975},new int[] {659,976},new int[] {620,977},
                new int[] {381,978},new int[] {607,979},new int[] {322,980},new int[] {367,981},new int[] {580,982},new int[] {814,983},new int[] {117,984},new int[] {502,985},
                new int[] {826,986},new int[] {917,987},new int[] {689,988},new int[] {206,989},new int[] {807,990},new int[] {388,991},new int[] {425,992},new int[] {572,993},
                new int[] {143,994},new int[] {573,995},new int[] {492,996},new int[] {910,997},new int[] {713,998},new int[] {69,999},new int[] {797,1000},new int[] {738,1001},
                new int[] {259,1002},new int[] {951,1003},new int[] {748,1004},new int[] {979,1005},new int[] {371,1006},new int[] {270,1007},new int[] {354,1008},new int[] {290,1009},
                new int[] {184,1010},new int[] {560,1011},new int[] {746,1012},new int[] {955,1013},new int[] {832,1014},new int[] {633,1015},new int[] {330,1016},new int[] {840,1017},
                new int[] {649,1018},new int[] {614,1019},new int[] {885,1020},new int[] {896,1021},new int[] {684,1022},new int[] {285,1023},new int[] {671,1024},new int[] {995,1025},
                new int[] {613,1026},new int[] {549,1027},new int[] {519,1028},new int[] {853,1029},new int[] {280,1030},new int[] {620,1031},new int[] {265,1032},new int[] {546,1033},
                new int[] {914,1034},new int[] {797,1035},new int[] {647,1036},new int[] {274,1037},new int[] {328,1038},new int[] {681,1039},new int[] {175,1040},new int[] {0,1041},
                new int[] {1019,1042},new int[] {829,1043},new int[] {420,1044},new int[] {513,1045},new int[] {835,1046},new int[] {845,1047},new int[] {351,1048},new int[] {960,1049},
                new int[] {414,1050},new int[] {839,1051},new int[] {805,1052},new int[] {959,1053},new int[] {984,1054},new int[] {819,1055},new int[] {188,1056},new int[] {937,1057},
                new int[] {1000,1058},new int[] {443,1059},new int[] {946,1060},new int[] {122,1061},new int[] {871,1062},new int[] {91,1063},new int[] {207,1064},new int[] {473,1065},
                new int[] {12,1066},new int[] {314,1067},new int[] {205,1068},new int[] {423,1069},new int[] {155,1070},new int[] {557,1071},new int[] {207,1072},new int[] {40,1073},
                new int[] {338,1074},new int[] {714,1075},new int[] {802,1076},new int[] {346,1077},new int[] {1026,1078},new int[] {32,1079},new int[] {231,1080},new int[] {347,1081},
                new int[] {1064,1082},new int[] {750,1083},new int[] {1072,1084},new int[] {542,1085},new int[] {405,1086},new int[] {908,1087},new int[] {835,1088},new int[] {534,1089},
                new int[] {656,1090},new int[] {789,1091},new int[] {1011,1092},new int[] {335,1093},new int[] {787,1094},new int[] {82,1095},new int[] {714,1096},new int[] {471,1097},
                new int[] {759,1098},new int[] {270,1099},new int[] {136,1100},new int[] {792,1101},new int[] {982,1102},new int[] {782,1103},new int[] {965,1104},new int[] {1024,1105},
                new int[] {1065,1106},new int[] {395,1107},new int[] {134,1108},new int[] {479,1109},new int[] {565,1110},new int[] {152,1111},new int[] {1014,1112},new int[] {504,1113},
                new int[] {533,1114},new int[] {813,1115},new int[] {196,1116},new int[] {1084,1117},new int[] {597,1118},new int[] {477,1119},new int[] {546,1120},new int[] {732,1121},
                new int[] {337,1122},new int[] {395,1123},new int[] {320,1124},new int[] {428,1125},new int[] {915,1126},new int[] {868,1127},new int[] {55,1128},new int[] {160,1129},
                new int[] {647,1130},new int[] {305,1131},new int[] {926,1132},new int[] {1007,1133},new int[] {747,1134},new int[] {13,1135},new int[] {1094,1136},new int[] {249,1137},
                new int[] {720,1138},new int[] {752,1139},new int[] {1114,1140},new int[] {173,1141},new int[] {553,1142},new int[] {1051,1143},new int[] {473,1144},new int[] {765,1145},
                new int[] {646,1146},new int[] {25,1147},new int[] {480,1148},new int[] {129,1149},new int[] {397,1150},new int[] {700,1151},new int[] {829,1152},new int[] {611,1153},
                new int[] {384,1154},new int[] {709,1155},new int[] {539,1156},new int[] {896,1157},new int[] {199,1158},new int[] {721,1159},new int[] {977,1160},new int[] {941,1161},
                new int[] {685,1162},new int[] {1145,1163},new int[] {949,1164},new int[] {176,1165},new int[] {226,1166},new int[] {821,1167},new int[] {661,1168},new int[] {487,1169},
                new int[] {1152,1170},new int[] {557,1171},new int[] {588,1172},new int[] {766,1173},new int[] {682,1174},new int[] {737,1175},new int[] {291,1176},new int[] {334,1177},
                new int[] {925,1178},new int[] {337,1179},new int[] {1004,1180},new int[] {743,1181},new int[] {746,1182},new int[] {80,1183},new int[] {153,1184},new int[] {631,1185},
                new int[] {546,1186},new int[] {419,1187},new int[] {435,1188},new int[] {507,1189},new int[] {977,1190},new int[] {1113,1191},new int[] {221,1192},new int[] {510,1193},
                new int[] {916,1194},new int[] {234,1195},new int[] {91,1196},new int[] {307,1197},new int[] {474,1198},new int[] {1176,1199},new int[] {7,1200},new int[] {846,1201},
                new int[] {754,1202},new int[] {1061,1203},new int[] {1086,1204},new int[] {746,1205},new int[] {950,1206},new int[] {23,1207},new int[] {705,1208},new int[] {821,1209},
                new int[] {48,1210},new int[] {603,1211},new int[] {848,1212},new int[] {85,1213},new int[] {1122,1214},new int[] {717,1215},new int[] {954,1216},new int[] {240,1217},
                new int[] {875,1218},new int[] {372,1219},new int[] {87,1220},new int[] {588,1221},new int[] {736,1222},new int[] {1169,1223},new int[] {422,1224},new int[] {237,1225},
                new int[] {1065,1226},new int[] {1203,1227},new int[] {558,1228},new int[] {51,1229},new int[] {1100,1230},new int[] {1179,1231},new int[] {671,1232},new int[] {806,1233},
                new int[] {708,1234},new int[] {15,1235},new int[] {347,1236},new int[] {794,1237},new int[] {101,1238},new int[] {336,1239},new int[] {1231,1240},new int[] {4,1241},
                new int[] {430,1242},new int[] {1077,1243},new int[] {1224,1244},new int[] {419,1245},new int[] {54,1246},new int[] {1187,1247},new int[] {899,1248},new int[] {1110,1249},
                new int[] {1165,1250},new int[] {277,1251},new int[] {41,1252},new int[] {723,1253},new int[] {1143,1254},new int[] {440,1255},new int[] {353,1256},new int[] {118,1257},
                new int[] {105,1258},new int[] {1250,1259},new int[] {820,1260},new int[] {373,1261},new int[] {414,1262},new int[] {556,1263},new int[] {610,1264},new int[] {721,1265},
                new int[] {497,1266},new int[] {596,1267},new int[] {66,1268},new int[] {302,1269},new int[] {865,1270},new int[] {0,1271},new int[] {1216,1272},new int[] {398,1273},
                new int[] {830,1274},new int[] {1258,1275},new int[] {1092,1276},new int[] {843,1277},new int[] {269,1278},new int[] {935,1279},new int[] {600,1280},new int[] {882,1281},
                new int[] {835,1282},new int[] {544,1283},new int[] {508,1284},new int[] {33,1285},new int[] {578,1286},new int[] {1052,1287},new int[] {281,1288},new int[] {492,1289},
                new int[] {293,1290},new int[] {1071,1291},new int[] {779,1292},new int[] {5,1293},new int[] {982,1294},new int[] {1195,1295},new int[] {1155,1296},new int[] {965,1297},
                new int[] {949,1298},new int[] {455,1299},new int[] {37,1300},new int[] {433,1301},new int[] {908,1302},new int[] {640,1303},new int[] {593,1304},new int[] {438,1305},
                new int[] {366,1306},new int[] {849,1307},new int[] {289,1308},new int[] {1028,1309},new int[] {1059,1310},new int[] {1022,1311},new int[] {351,1312},new int[] {274,1313},
                new int[] {1031,1314},new int[] {836,1315},new int[] {291,1316},new int[] {879,1317},new int[] {466,1318},new int[] {786,1319},new int[] {755,1320},new int[] {582,1321},
                new int[] {1137,1322},new int[] {168,1323},new int[] {217,1324},new int[] {739,1325},new int[] {1,1326},new int[] {47,1327},new int[] {1239,1328},new int[] {1199,1329},
                new int[] {640,1330},new int[] {917,1331},new int[] {167,1332},new int[] {894,1333},new int[] {1240,1334},new int[] {130,1335},new int[] {1333,1336},new int[] {164,1337},
                new int[] {302,1338},new int[] {1115,1339},new int[] {1237,1340},new int[] {1222,1341},new int[] {710,1342},new int[] {446,1343},new int[] {825,1344},new int[] {152,1345},
                new int[] {794,1346},new int[] {1242,1347},new int[] {80,1348},new int[] {596,1349},new int[] {674,1350},new int[] {204,1351},new int[] {859,1352},new int[] {105,1353},
                new int[] {918,1354},new int[] {795,1355},new int[] {528,1356},new int[] {960,1357},new int[] {108,1358},new int[] {591,1359},new int[] {1138,1360},new int[] {881,1361},
                new int[] {167,1362},new int[] {214,1363},new int[] {288,1364},new int[] {97,1365},new int[] {1,1366},new int[] {1091,1367},new int[] {1185,1368},new int[] {386,1369},
                new int[] {11,1370},new int[] {319,1371},new int[] {1353,1372},new int[] {1237,1373},new int[] {367,1374},new int[] {954,1375},new int[] {172,1376},new int[] {133,1377},
                new int[] {312,1378},new int[] {647,1379},new int[] {614,1380},new int[] {82,1381},new int[] {968,1382},new int[] {232,1383},new int[] {1236,1384},new int[] {1025,1385},
                new int[] {262,1386},new int[] {247,1387},new int[] {398,1388},new int[] {407,1389},new int[] {552,1390},new int[] {1269,1391},new int[] {1334,1392},new int[] {1164,1393},
                new int[] {864,1394},new int[] {531,1395},new int[] {643,1396},new int[] {124,1397},new int[] {469,1398},new int[] {20,1399},new int[] {152,1400},new int[] {806,1401},
                new int[] {671,1402},new int[] {727,1403},new int[] {257,1404},new int[] {666,1405},new int[] {747,1406},new int[] {1171,1407},new int[] {892,1408},new int[] {129,1409},
                new int[] {655,1410},new int[] {652,1411},new int[] {781,1412},new int[] {877,1413},new int[] {452,1414},new int[] {287,1415},new int[] {114,1416},new int[] {1101,1417},
                new int[] {901,1418},new int[] {6,1419},new int[] {1154,1420},new int[] {660,1421},new int[] {357,1422},new int[] {750,1423},new int[] {602,1424},new int[] {460,1425},
                new int[] {584,1426},new int[] {697,1427},new int[] {1082,1428},new int[] {643,1429},new int[] {127,1430},new int[] {1356,1431},new int[] {823,1432},new int[] {492,1433},
                new int[] {507,1434},new int[] {1175,1435},new int[] {1,1436},new int[] {333,1437},new int[] {598,1438},new int[] {1382,1439},new int[] {556,1440},new int[] {1278,1441},
                new int[] {172,1442},new int[] {438,1443},new int[] {917,1444},new int[] {650,1445},new int[] {501,1446},new int[] {733,1447},new int[] {1066,1448},new int[] {317,1449},
                new int[] {185,1450},new int[] {1217,1451},new int[] {384,1452},new int[] {105,1453},new int[] {661,1454},new int[] {1270,1455},new int[] {1312,1456},new int[] {363,1457},
                new int[] {1363,1458},new int[] {319,1459},new int[] {132,1460},new int[] {1406,1461},new int[] {643,1462},new int[] {1436,1463},new int[] {1169,1464},new int[] {1175,1465},
                new int[] {897,1466},new int[] {963,1467},new int[] {1050,1468},new int[] {817,1469},new int[] {563,1470},new int[] {646,1471},new int[] {1281,1472},new int[] {1342,1473},
                new int[] {759,1474},new int[] {1468,1475},new int[] {557,1476},new int[] {1400,1477},new int[] {358,1478},new int[] {1272,1479},new int[] {1360,1480},new int[] {226,1481},
                new int[] {615,1482},new int[] {1239,1483},new int[] {231,1484},new int[] {780,1485},new int[] {257,1486},new int[] {1462,1487},new int[] {1309,1488},new int[] {59,1489},
                new int[] {1065,1490},new int[] {508,1491},new int[] {1345,1492},new int[] {1200,1493},new int[] {1114,1494},new int[] {12,1495},new int[] {603,1496},new int[] {544,1497},
                new int[] {167,1498},new int[] {471,1499},new int[] {110,1500},new int[] {1089,1501},new int[] {608,1502},new int[] {189,1503},new int[] {543,1504},new int[] {304,1505},
                new int[] {1169,1506},new int[] {669,1507},new int[] {215,1508},new int[] {397,1509},new int[] {679,1510},new int[] {363,1511},new int[] {1007,1512},new int[] {961,1513},
                new int[] {652,1514},new int[] {267,1515},new int[] {425,1516},new int[] {74,1517},new int[] {544,1518},new int[] {806,1519},new int[] {1508,1520},new int[] {800,1521},
                new int[] {649,1522},new int[] {223,1523},new int[] {629,1524},new int[] {585,1525},new int[] {227,1526},new int[] {298,1527},new int[] {448,1528},new int[] {237,1529},
                new int[] {502,1530},new int[] {227,1531},new int[] {1302,1532},new int[] {426,1533},new int[] {1188,1534},new int[] {310,1535},new int[] {1448,1536},new int[] {1122,1537},
                new int[] {1391,1538},new int[] {393,1539},new int[] {194,1540},new int[] {1381,1541},new int[] {551,1542},new int[] {637,1543},new int[] {227,1544},new int[] {407,1545},
                new int[] {88,1546},new int[] {636,1547},new int[] {1065,1548},new int[] {847,1549},new int[] {1270,1550},new int[] {232,1551},new int[] {169,1552},new int[] {465,1553},
                new int[] {332,1554},new int[] {1146,1555},new int[] {1516,1556},new int[] {1108,1557},new int[] {1082,1558},new int[] {382,1559},new int[] {877,1560},new int[] {1198,1561},
                new int[] {1480,1562},new int[] {376,1563},new int[] {1182,1564},new int[] {827,1565},new int[] {376,1566},new int[] {979,1567},new int[] {803,1568},new int[] {790,1569},
                new int[] {1339,1570},new int[] {202,1571},new int[] {574,1572},new int[] {1472,1573},new int[] {376,1574},new int[] {1380,1575},new int[] {305,1576},new int[] {1431,1577},
                new int[] {1504,1578},new int[] {640,1579},new int[] {1515,1580},new int[] {154,1581},new int[] {584,1582},new int[] {971,1583},new int[] {657,1584},new int[] {1439,1585},
                new int[] {162,1586},new int[] {949,1587},new int[] {194,1588},new int[] {498,1589},new int[] {831,1590},new int[] {194,1591},new int[] {573,1592},new int[] {638,1593},
                new int[] {288,1594},new int[] {356,1595},new int[] {1495,1596},new int[] {718,1597},new int[] {88,1598},new int[] {512,1599},new int[] {530,1600},new int[] {1354,1601},
                new int[] {887,1602},new int[] {908,1603},new int[] {491,1604},new int[] {733,1605},new int[] {245,1606},new int[] {373,1607},new int[] {413,1608},new int[] {614,1609},
                new int[] {112,1610},new int[] {350,1611},new int[] {411,1612},new int[] {216,1613},new int[] {1290,1614},new int[] {462,1615}
            };
            var result5 = solution.FindMinHeightTrees(1616, edges5);
        }
    }
}
