// This code was generated by a kontent-generators-net tool 
// (see https://github.com/Kentico/kontent-generators-net).
// 
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated. 
// For further modifications of the class, create a separate file with the partial class.

using System;
using System.Collections.Generic;
using Kentico.Kontent.Delivery.Abstractions;

namespace FromZeroToHero.Models.ContentTypes
{
    public partial class Page
    {
        public const string Codename = "page";
        public const string SubpagesCodename = "subpages";
        public const string TitleCodename = "title";
        public const string UrlCodename = "url";

        public IEnumerable<object> Subpages { get; set; }
        public IContentItemSystemAttributes System { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}