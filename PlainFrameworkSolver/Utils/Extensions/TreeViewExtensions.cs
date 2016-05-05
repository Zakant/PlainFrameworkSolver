using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlainFrameworkSolver.Utils.Extensions
{
    public static class TreeViewExtensions
    {
        public static IEnumerable<T> FindAllNodes<T>(this TreeView treeView) where T : TreeNode
        {
            return getAllNodes(treeView.Nodes).Where(x => x is T).Select(x => (T)x);
        }
        public static T SelectNode<T>(this TreeView treeView, Predicate<T> predicate) where T : TreeNode
        {
            return FindAllNodes<T>(treeView).FirstOrDefault(x => predicate(x));
        }

        private static IEnumerable<TreeNode> getAllNodes(TreeNodeCollection collection)
        {
            foreach (var n in collection)
            {
                yield return (TreeNode)n;
                foreach (var x in getAllNodes(((TreeNode)n).Nodes)) yield return x;
            }
        }
    }
}
