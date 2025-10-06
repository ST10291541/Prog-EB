namespace SimpleTrees
{
    public class Program
    {
        static void Main(string[] args)
        {
            // ---------------------------
            // Build Organizational Hierarchy
            // ---------------------------
            OrgTree org = new OrgTree("CEO: Zanele");

            var cio = new TreeNode<string>("CIO: Thabo");
            var cfo = new TreeNode<string>("CFO: Pieter");
            var coo = new TreeNode<string>("COO: Lerato");
            var cto = new TreeNode<string>("CTO: Sifiso");

            org.Root.AddChild(cio);
            org.Root.AddChild(cfo);
            org.Root.AddChild(coo);
            org.Root.AddChild(cto);

            // CIO branch
            var softwareMgr = new TreeNode<string>("Software Development Manager: Linda");
            var dev = new TreeNode<string>("Developer: Lindiwe");
            cio.AddChild(softwareMgr);
            softwareMgr.AddChild(dev);

            // CFO branch
            var accountant = new TreeNode<string>("Accountant: Muhammad");
            cfo.AddChild(accountant);

            // COO branch
            var opsMgr = new TreeNode<string>("Operations Manager: Nomsa");
            coo.AddChild(opsMgr);

            // CTO branch
            var techLead = new TreeNode<string>("Tech Lead: Megan");
            cto.AddChild(techLead);

            // ---------------------------
            // Traversals
            // ---------------------------
            Console.WriteLine("===== PRE-ORDER TRAVERSAL =====");
            org.PreOrder(org.Root);
            Console.WriteLine();

            Console.WriteLine("===== IN-ORDER TRAVERSAL =====");
            org.InOrder(org.Root);
            Console.WriteLine();

            Console.WriteLine("===== POST-ORDER TRAVERSAL =====");
            org.PostOrder(org.Root);
            Console.WriteLine();

            Console.WriteLine("===== LEVEL-ORDER TRAVERSAL =====");
            org.LevelOrder();
            Console.WriteLine();

            // ---------------------------
            // Search Example
            // ---------------------------
            Console.Write("Enter an employee name to search: ");
            string searchName = Console.ReadLine();

            var found = org.Search(org.Root, searchName);
            if (found != null)
                Console.WriteLine($"Found: {found.Data}");
            else
                Console.WriteLine("Employee not found.");
        }
    }
    
}
