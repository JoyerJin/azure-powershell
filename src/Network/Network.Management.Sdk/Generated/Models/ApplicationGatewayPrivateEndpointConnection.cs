// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.Network.Models
{
    using System.Linq;

    /// <summary>
    /// Private Endpoint connection on an application gateway.
    /// </summary>
    [Microsoft.Rest.Serialization.JsonTransformation]
    public partial class ApplicationGatewayPrivateEndpointConnection : SubResource
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationGatewayPrivateEndpointConnection class.
        /// </summary>
        public ApplicationGatewayPrivateEndpointConnection()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ApplicationGatewayPrivateEndpointConnection class.
        /// </summary>

        /// <param name="id">Resource ID.
        /// </param>

        /// <param name="name">Name of the private endpoint connection on an application gateway.
        /// </param>

        /// <param name="etag">A unique read-only string that changes whenever the resource is updated.
        /// </param>

        /// <param name="type">Type of the resource.
        /// </param>

        /// <param name="privateEndpoint">The resource of private end point.
        /// </param>

        /// <param name="provisioningState">The provisioning state of the application gateway private endpoint
        /// connection resource.
        /// Possible values include: &#39;Failed&#39;, &#39;Succeeded&#39;, &#39;Canceled&#39;, &#39;Creating&#39;,
        /// &#39;Updating&#39;, &#39;Deleting&#39;</param>

        /// <param name="privateLinkServiceConnectionState">A collection of information about the state of the connection between
        /// service consumer and provider.
        /// </param>

        /// <param name="linkIdentifier">The consumer link id.
        /// </param>
        public ApplicationGatewayPrivateEndpointConnection(string id = default(string), string name = default(string), string etag = default(string), string type = default(string), PrivateEndpoint privateEndpoint = default(PrivateEndpoint), string provisioningState = default(string), PrivateLinkServiceConnectionState privateLinkServiceConnectionState = default(PrivateLinkServiceConnectionState), string linkIdentifier = default(string))

        : base(id)
        {
            this.Name = name;
            this.Etag = etag;
            this.Type = type;
            this.PrivateEndpoint = privateEndpoint;
            this.ProvisioningState = provisioningState;
            this.PrivateLinkServiceConnectionState = privateLinkServiceConnectionState;
            this.LinkIdentifier = linkIdentifier;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets name of the private endpoint connection on an application
        /// gateway.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name {get; set; }

        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource is
        /// updated.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "etag")]
        public string Etag {get; private set; }

        /// <summary>
        /// Gets type of the resource.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "type")]
        public string Type {get; private set; }

        /// <summary>
        /// Gets the resource of private end point.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.privateEndpoint")]
        public PrivateEndpoint PrivateEndpoint {get; private set; }

        /// <summary>
        /// Gets the provisioning state of the application gateway private endpoint
        /// connection resource. Possible values include: &#39;Failed&#39;, &#39;Succeeded&#39;, &#39;Canceled&#39;, &#39;Creating&#39;, &#39;Updating&#39;, &#39;Deleting&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState {get; private set; }

        /// <summary>
        /// Gets or sets a collection of information about the state of the connection
        /// between service consumer and provider.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.privateLinkServiceConnectionState")]
        public PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState {get; set; }

        /// <summary>
        /// Gets the consumer link id.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.linkIdentifier")]
        public string LinkIdentifier {get; private set; }
    }
}