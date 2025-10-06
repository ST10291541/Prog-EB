using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrees
{
    public class OrgTree
    {
        public TreeNode<string> Root { get; private set; }

        public OrgTree(string rootData)
        {
            Root = new TreeNode<string>(rootData);
        }

        // ---------------------------
        // Traversal Methods
        // ---------------------------

        // Pre-order (Root → Children)
        public void PreOrder(TreeNode<string> node)
        {
            if (node == null) return;

            Console.WriteLine(node.Data);
            foreach (var child in node.Children)
                PreOrder(child);
        }

        // Post-order (Children → Root)
        public void PostOrder(TreeNode<string> node)
        {
            if (node == null) return;

            foreach (var child in node.Children)
                PostOrder(child);

            Console.WriteLine(node.Data);
        }

        // In-order (Left child → Root → Right children)
        public void InOrder(TreeNode<string> node)
        {
            if (node == null) return;

            if (node.Children.Count > 0)
                InOrder(node.Children[0]);

            Console.WriteLine(node.Data);

            for (int i = 1; i < node.Children.Count; i++)
                InOrder(node.Children[i]);
        }

        // Level-order (Breadth-first)
        public void LevelOrder()
        {
            if (Root == null) return;

            Queue<TreeNode<string>> queue = new Queue<TreeNode<string>>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                TreeNode<string> current = queue.Dequeue();
                Console.WriteLine(current.Data);

                foreach (var child in current.Children)
                    queue.Enqueue(child);
            }
        }

        // ---------------------------
        // Search Function (DFS)
        // ---------------------------
        public TreeNode<string> Search(TreeNode<string> node, string name)
        {
            if (node == null) return null;

            if (node.Data.Contains(name, StringComparison.OrdinalIgnoreCase))
                return node;

            foreach (var child in node.Children)
            {
                var result = Search(child, name);
                if (result != null)
                    return result;
            }

            return null;
        }
    }
}
