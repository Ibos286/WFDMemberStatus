using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static List<Member> AsList<Member>(this ICollectionView collectionView)
        {
            return collectionView.Cast<Member>().ToList();
        }
    }
}
