// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.Logic.Models
{
    using System.Linq;

    /// <summary>
    /// The JSON schema.
    /// </summary>
    public partial class JsonSchema
    {
        /// <summary>
        /// Initializes a new instance of the JsonSchema class.
        /// </summary>
        public JsonSchema()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the JsonSchema class.
        /// </summary>

        /// <param name="title">The JSON title.
        /// </param>

        /// <param name="content">The JSON content.
        /// </param>
        public JsonSchema(string title = default(string), string content = default(string))

        {
            this.Title = title;
            this.Content = content;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets the JSON title.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "title")]
        public string Title {get; set; }

        /// <summary>
        /// Gets or sets the JSON content.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "content")]
        public string Content {get; set; }
    }
}