using System.Collections.Generic;

namespace CubeXNative
{
    public class ItemVerticals
    {
        public string code { get; set; }
        public string name { get; set; }
        public string itemList { get; set; }
        public List<ItemVerticalList> itemVerticals { get; set; }

    }

    public class ItemVerticalList
    {
        public int vertical_id { get; set; }
        public string vertical_name { get; set; }
    }

}