using PetStoreSchema.Models;
using System.Linq;
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.13.2.0 (NJsonSchema v10.5.2.0 (Newtonsoft.Json v12.0.0.2)) (http://NSwag.org)
// </auto-generated>
//----------------------

#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."
#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"
#pragma warning disable 3016 // Disable "CS3016 Arrays as attribute arguments is not CLS-compliant"

namespace OrderController
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.13.2.0 (NJsonSchema v10.5.2.0 (Newtonsoft.Json v12.0.0.2))")]
    public interface IOrderController
    {
        /// <summary>Returns pet inventories by status</summary>
        /// <returns>successful operation</returns>
        System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IDictionary<string, int>>> GetInventoryAsync();
    
        /// <summary>Place an order for a pet</summary>
        /// <param name="body">order placed for purchasing the pet</param>
        /// <returns>successful operation</returns>
        System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<Order>> PlaceOrderAsync(Order body);
    
        /// <summary>Find purchase order by ID</summary>
        /// <param name="orderId">ID of pet that needs to be fetched</param>
        /// <returns>successful operation</returns>
        System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<Order>> GetOrderByIdAsync(long orderId);
    
        /// <summary>Delete purchase order by ID</summary>
        /// <param name="orderId">ID of the order that needs to be deleted</param>
        /// <returns>Success</returns>
        System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> DeleteOrderAsync(long orderId);

        public Microsoft.AspNetCore.Mvc.Controller LzController { get; set; }

        public string LzUserId {get; set;}

        public void LzGetUserId()
        {
            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            Microsoft.Extensions.Primitives.StringValues header;
            var foundHeader = LzController.Request.Headers.TryGetValue("Authorization", out header);
            if (!foundHeader || header[0].ToString().StartsWith("AWS4-HMAC-SHA256 Credential="))
                foundHeader = LzController.Request.Headers.TryGetValue("LzIdentity", out header);
            if (foundHeader)
            {
                if (handler.CanReadToken(header))
                {
                    var jwtToken = handler.ReadJwtToken(header);
                    var claim = jwtToken?.Claims.Where(x => x.Type.Equals("sub")).FirstOrDefault();
                    LzUserId = claim?.Value;
                }
            }
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.13.2.0 (NJsonSchema v10.5.2.0 (Newtonsoft.Json v12.0.0.2))")]
    public partial class OrderController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IOrderController _implementation;
    
        public OrderController(IOrderController implementation)
        {
            _implementation = implementation;			_implementation.LzController = this;
        }
    
        /// <summary>Returns pet inventories by status</summary>
        /// <returns>successful operation</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("order/inventory")]
        public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IDictionary<string, int>>> GetInventory()
        {
            _implementation.LzGetUserId();			return _implementation.GetInventoryAsync();
        }
    
        /// <summary>Place an order for a pet</summary>
        /// <param name="body">order placed for purchasing the pet</param>
        /// <returns>successful operation</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("order")]
        public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<Order>> PlaceOrder([Microsoft.AspNetCore.Mvc.FromBody] Order body)
        {
            _implementation.LzGetUserId();			return _implementation.PlaceOrderAsync(body);
        }
    
        /// <summary>Find purchase order by ID</summary>
        /// <param name="orderId">ID of pet that needs to be fetched</param>
        /// <returns>successful operation</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("order/{orderId}")]
        public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<Order>> GetOrderById(long orderId)
        {
            _implementation.LzGetUserId();			return _implementation.GetOrderByIdAsync(orderId);
        }
    
        /// <summary>Delete purchase order by ID</summary>
        /// <param name="orderId">ID of the order that needs to be deleted</param>
        /// <returns>Success</returns>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("order/{orderId}")]
        public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> DeleteOrder(long orderId)
        {
            _implementation.LzGetUserId();			return _implementation.DeleteOrderAsync(orderId);
        }
    
    }

}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108
#pragma warning restore 3016