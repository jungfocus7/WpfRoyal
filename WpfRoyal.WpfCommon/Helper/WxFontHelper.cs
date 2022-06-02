namespace WpfRoyal.WpfCommon.Helper
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Media;






    public static class WxFontHelper
    {
        //private class ProductComparer : IEqualityComparer<Product>
        //{
        //    // Products are equal if their names and product numbers are equal.
        //    public bool Equals(Product x, Product y)
        //    {

        //        //Check whether the compared objects reference the same data.
        //        if (Object.ReferenceEquals(x, y)) return true;

        //        //Check whether any of the compared objects is null.
        //        if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
        //            return false;

        //        //Check whether the products' properties are equal.
        //        return x.Code == y.Code && x.Name == y.Name;
        //    }

        //    // If Equals() returns true for a pair of objects
        //    // then GetHashCode() must return the same value for these objects.

        //    public int GetHashCode(Product product)
        //    {
        //        //Check whether the object is null
        //        if (Object.ReferenceEquals(product, null)) return 0;

        //        //Get hash code for the Name field if it is not null.
        //        int hashProductName = product.Name == null ? 0 : product.Name.GetHashCode();

        //        //Get hash code for the Code field.
        //        int hashProductCode = product.Code.GetHashCode();

        //        //Calculate the hash code for the product.
        //        return hashProductName ^ hashProductCode;
        //    }
        //}



        private static ICollection<Typeface> _typefaces;
        private static IEnumerable<string> _names;


        public static void LoadForReady()
        {
            if (_typefaces == null)
                _typefaces = Fonts.SystemTypefaces;
        }

        public static void Clear()
        {
            if (_typefaces == null) return;
            _typefaces = null;
        }


        public static IEnumerable<string> GetSystemFontNames()
        {
            if (_names == null)
            {
                _names = _typefaces.Select(tx => tx.FontFamily.Source);
                _names = _names.Distinct();
            }
            return _names;
        }

    }


}
