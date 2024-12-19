using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Piramida.Logic.DtoModels.Filters;
using Piramida.Storage.Models;
using Piramida_web.Features.DtoModels.Admission;
using Piramida_web.Features.DtoModels.Cart;
using Piramida_web.Features.DtoModels.Cart_product;
using Piramida_web.Features.DtoModels.Client;
using Piramida_web.Features.DtoModels.Employee;
using Piramida_web.Features.DtoModels.Feedback;
using Piramida_web.Features.DtoModels.Product;
using Piramida_web.Features.DtoModels.Product_property;
using Piramida_web.Features.DtoModels.Sale;
using Piramida_web.Features.DtoModels.Sale_product_property;
using Piramida_web.Features.DtoModels.Season_ticket;
using Piramida_web.Features.Filters;
using Piramida_web.Features.Interface;
using Piramida_web.User;
using System.IdentityModel.Tokens.Jwt;

namespace Piramida_web.Controllers
{
    public class PatientNotFoundException : Exception
    {
        public PatientNotFoundException(string message) : base(message) { }
    }
    [Route("[controller]")]
    public class ManageController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAdmissionManager _admissionManager;
        private readonly IClientManager _clientManager;
        private readonly IEmployeeManager _employeeManager;
        private readonly IFeedbackManager _feedbackManager;
        private readonly IProduct_propertyManager _product_propertyManager;
        private readonly IProductManager _productManager;
        private readonly ISaleManager _saleManager;
        private readonly ICartManager _cartManager;
        private readonly IImagesForSpailnManager _imagesForSpailnManager;
        private readonly ICart_productManager _cart_productManager;
        private readonly ISale_product_propertyManager _sale_product_propertyManager;
        private readonly ISeason_ticketManager _season_ticketManager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public const string Manage = "Manage";

        public ManageController(ILogger<HomeController> logger, IAdmissionManager admissionManager, IClientManager clientManager, IEmployeeManager employeeManager, IFeedbackManager feedbackManager,
        IProduct_propertyManager product_propertyManager, IImagesForSpailnManager imagesForSpailnManager, ICart_productManager cart_productManager, IProductManager productManager, ISaleManager saleManager, ICartManager cartManager, ISale_product_propertyManager sale_product_propertyManager, ISeason_ticketManager season_ticketManager,
        IMapper mapper, IWebHostEnvironment env)
        {
            _logger = logger;
            _imagesForSpailnManager = imagesForSpailnManager;
            _admissionManager = admissionManager;
            _clientManager = clientManager;
            _cartManager = cartManager;
            _cart_productManager = cart_productManager;
            _employeeManager = employeeManager;
            _feedbackManager = feedbackManager;
            _product_propertyManager = product_propertyManager;
            _productManager = productManager;
            _saleManager = saleManager;
            _sale_product_propertyManager = sale_product_propertyManager;
            _season_ticketManager = season_ticketManager;
            _mapper = mapper;
            _env = env;


        }

        #region Admission
        [HttpGet(nameof(Admission), Name = nameof(Admission))]

        public async Task<ActionResult> Admission()
        {
            var admission = _admissionManager.GetListAdmission(new AdmissionFilterDto()).FirstOrDefault();
            return View(admission);
        }

        [HttpPost(nameof(CreatAdmission), Name = nameof(CreatAdmission))]
        public async Task<ActionResult> CreatAdmission([FromBody] AdmissionRequest request)
        {
            var admission = new EditAdmissionDto
            {
                ClientId = request.Client.Id,
                ProductId = request.Product.Id,
                Id = Guid.NewGuid(),
                Time = request.Time,
                EmployeeId = request.Employee.Id
            };
            _admissionManager.Creat(admission);
            return Ok();
        }

        [HttpPut(nameof(UpdateAdmission), Name = nameof(UpdateAdmission))]
        public async Task<ActionResult> UpdateAdmission([FromBody] EditAdmissionDto admission)
        {
            _admissionManager.Update(admission);
            return Ok();
        }

        [HttpPost(nameof(DeleteAdmission), Name = nameof(DeleteAdmission))]
        public async Task<ActionResult> DeleteAdmission([FromQuery] Guid Id)
        {
            _admissionManager.Delete(Id);
            return Ok();
        }

        [HttpGet(nameof(GetListAdmissions), Name = nameof(GetListAdmissions))]
        public async Task<ActionResult> GetListAdmissions()
        {
            var list = _admissionManager.GetListAdmissionByEmployee(null);
            return View(list);
        }
        #endregion

        #region Client

        [HttpGet(nameof(RegClient), Name = nameof(RegClient))]

        public ActionResult RegClient()
        {
            return View(new EditClientDto());
        }

        [HttpGet(nameof(Client), Name = nameof(Client))]
        public async Task<ActionResult> Client()
        {
            var client = _clientManager.GetListClient(new ClientFilterDto()).FirstOrDefault();
            return View(client);
        }

        [HttpPost(nameof(CreatClient), Name = nameof(CreatClient))]
        public async Task<ActionResult> CreatClient([FromBody] EditClientDto client)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                //client.Id = Guid.NewGuid();
                //System.Console.WriteLine("Случайный Guid");
                //System.Console.WriteLine($"doctor: {doctor.IsnNode}\n{doctor.First_Name}\n{doctor.Certificate}\n{doctor.Post}\n{doctor.office}\nend");
                //GetListDoctor();
                var clientuse = SearchAccount(client.Telephone, client.Email);
                System.Console.WriteLine("Controller");
                if (clientuse != null)
                {
                    return Conflict(new { message = "A client with the same telephone or email or login already exists." });
                }

                _clientManager.Creat(client);
                //System.Console.WriteLine($"Случайный Guid:{ClientUser.clientuser.First_Name}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a doctor.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost(nameof(CreatClientView), Name = nameof(CreatClientView))]
        public async Task<ActionResult> CreatClientView([FromBody] EditClientDto client)
        {
            if (!ModelState.IsValid)
                return View(nameof(client), client);
            _clientManager.Creat(client);
            return View();
        }

        [HttpPut(nameof(UpdateClient), Name = nameof(UpdateClient))]
        public async Task<ActionResult> UpdateClient([FromBody] EditClientDto clientDto)
        {
            _clientManager.Update(clientDto);
            ClientUser.clientuser = _mapper.Map<ClientDto>(clientDto);
            return Ok();
        }

        [HttpGet(nameof(EditClient), Name = nameof(EditClient))]
        public async Task<ActionResult> EditClient()
        {
            return View(_mapper.Map<EditClientDto>(ClientUser.clientuser));
        }

        [HttpPost(nameof(DeleteClient), Name = nameof(DeleteClient))]
        public async Task<ActionResult> DeleteClient([FromQuery] Guid IsnNode)
        {
            _clientManager.Delete(IsnNode);
            return Ok();
        }

        [HttpGet(nameof(GetListClients), Name = nameof(GetListClients))]
        [ServiceFilter(typeof(DevelopmentOnlyFilter))]
        public async Task<ActionResult> GetListClients()
        {
            var list = _clientManager.GetListClient(null);
            return View(list);
        }

        //[HttpGet(nameof(GetUsername), Name = nameof(GetUsername))]
        //public async Task<ActionResult> GetUsername()
        //{
        //var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        //if (string.IsNullOrEmpty(token))
        //{
        //    return Unauthorized("Токен не найден");
        //}

        //// Декодируем токен и извлекаем ID пользователя
        //var claims = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims;
        //var userIdString = claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;

        //if (Guid.TryParse(userIdString, out Guid userId))
        //{
        //    return Json(new { username = _clientManager.GetClient(userId) }, JsonRequestBehavior.AllowGet);
        //}
        //else
        //{
        //    return BadRequest("Некорректный формат ID пользователя.");
        //}
        #endregion

        #region Cart
        [HttpPost(nameof(CreatCart), Name = nameof(CreatCart))]
        public async Task<ActionResult> CreatCart([FromBody] EditCartDto cart)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                //product_property.Id = Guid.NewGuid();
                //System.Console.WriteLine("Случайный Guid");
                //System.Console.WriteLine($"doctor: {doctor.IsnNode}\n{doctor.First_Name}\n{doctor.Certificate}\n{doctor.Post}\n{doctor.office}\nend");
                //GetListDoctor();

                _cartManager.Creat(cart);
                //System.Console.WriteLine($"Случайный Guid:{Product_propertyUser.product_propertyuser.First_Name}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a doctor.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet(nameof(FoundCart), Name = nameof(FoundCart))]
        [ServiceFilter(typeof(DevelopmentOnlyFilter))]
        public async Task<ActionResult> FoundCart()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Токен не найден");
            }

            // Декодируем токен и извлекаем ID пользователя
            var claims = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims;
            var userIdString = claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;

            if (Guid.TryParse(userIdString, out Guid userId))
            {
                var filter = new CartFilterDto
                {
                    Id = userId
                };
                var list = _cartManager.GetListCart(null);
                CartDto cartc;
                foreach (CartDto item in list)
                {
                    if (item.ClientId == userId) return Ok(item);
                }
                return Ok(_cartManager.Creat(new EditCartDto { ClientId = userId }));


            }
            else
            {
                return BadRequest("Некорректный формат ID пользователя.");
            }
        }


        [HttpGet(nameof(CartForCat), Name = nameof(CartForCat))]
        [ServiceFilter(typeof(DevelopmentOnlyFilter))]
        public async Task<ActionResult<IEnumerable<Cart_for_front>>> CartForCat()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Токен не найден");
            }

            // Декодируем токен и извлекаем ID пользователя
            var claims = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims;
            var userIdString = claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;

            if (Guid.TryParse(userIdString, out Guid userId))
            {
                var filter = new CartFilterDto
                {
                    Id = userId
                };
                var listcarts = _cartManager.GetListCartByClient(filter);
                var ncart = new EditCartDto { ClientId = userId };
                var cartToFilter = new CartDto();
                if (listcarts.Length == 0)
                {
                    cartToFilter = _cartManager.Creat(ncart);
                }
                else { cartToFilter = listcarts[0]; }
                var filter1 = new Cart_productFilterDto
                {
                    Id = cartToFilter.Id,
                };
                var list = _cart_productManager.GetListCart_productByCart(filter1);
                List<Cart_for_front> carts = new List<Cart_for_front>();
                foreach (Cart_productDto Prod in list)
                {
                    carts.Add(new Cart_for_front { Id = Prod.Id, ProductId = Prod.ProductId, Price = _productManager.GetProduct(Prod.ProductId).Price, CartId = Prod.CartId, count = Prod.count, Name = _productManager.GetProduct(Prod.ProductId).Name });

                }
                return Ok(carts);




            }
            else
            {
                return BadRequest("Некорректный формат ID пользователя.");
            }
        }

        [HttpGet(nameof(CartProducts), Name = nameof(CartProducts))]
        [ServiceFilter(typeof(DevelopmentOnlyFilter))]
        public async Task<ActionResult> CartProducts()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Токен не найден");
            }

            // Декодируем токен и извлекаем ID пользователя
            var claims = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims;
            var userIdString = claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;

            if (Guid.TryParse(userIdString, out Guid userId))
            {
                var filter = new CartFilterDto
                {
                    Id = userId
                };
                var list = _cartManager.GetListCart(null);
                CartDto cartc;
                foreach (CartDto item in list)
                {
                    if (item.ClientId == userId) return Ok(item);
                }
                return Ok(_cartManager.Creat(new EditCartDto { ClientId = userId }));


            }
            else
            {
                return BadRequest("Некорректный формат ID пользователя.");
            }
        }


        #endregion

        #region Cart_product

        [HttpPost(nameof(CreatCart_product), Name = nameof(CreatCart_product))]
        public async Task<ActionResult> CreatCart_product([FromBody] EditCart_productDto productId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Токен не найден");
                }

                // Декодируем токен и извлекаем ID пользователя
                var claims = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims;
                var userIdString = claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;

                if (Guid.TryParse(userIdString, out Guid userId))
                {
                    var filter = new CartFilterDto
                    {
                        Id = userId
                    };
                    var listcarts = _cartManager.GetListCartByClient(filter);
                    var ncart = new EditCartDto { ClientId = userId };
                    var cartToFilter = new CartDto();
                    if (listcarts.Length == 0)
                    {
                        cartToFilter = _cartManager.Creat(ncart);
                    }
                    else
                    {
                        cartToFilter = listcarts[0];
                    }
                    var filter1 = new Cart_productFilterDto
                    {
                        Id = cartToFilter.Id,
                    };
                    var list = _cart_productManager.GetListCart_productByCart(filter1);

                    foreach (Cart_productDto item in list)
                    {
                        if (item.ProductId == productId.ProductId)
                        {
                            var Upcart = new EditCart_productDto { Id = item.Id, ProductId = productId.ProductId, CartId = cartToFilter.Id, count = (item.count + 1) };
                            _cart_productManager.Update(Upcart);
                            return Ok();
                        }
                    }

                    var Cpcart = new EditCart_productDto { ProductId = productId.ProductId, CartId = cartToFilter.Id, count = 1 };
                    _cart_productManager.Creat(Cpcart);
                    return Ok();
                }
                else
                {
                    return BadRequest("Некорректный формат ID пользователя.");
                }

                //Console.WriteLine(productId);
                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a doctor.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost(nameof(UpdateCart_product), Name = nameof(UpdateCart_product))]
        public async Task<ActionResult> UpdateCart_product([FromBody] EditCart_productDto productId)
        {
            var retprod = _cart_productManager.GetCart_product(productId.Id);
            productId.ProductId = retprod.ProductId;
            productId.CartId = retprod.CartId;

            _cart_productManager.Update(productId);

            return Ok();

        }

        [HttpPost(nameof(ClearCart), Name = nameof(ClearCart))]
        public async Task<ActionResult> ClearCart()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Токен не найден");
            }

            // Декодируем токен и извлекаем ID пользователя
            var claims = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims;
            var userIdString = claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;

            if (Guid.TryParse(userIdString, out Guid userId))
            {
                var filter = new CartFilterDto
                {
                    Id = userId
                };
                var listcarts = _cartManager.GetListCartByClient(filter);

                var filter1 = new Cart_productFilterDto
                {
                    Id = listcarts[0].Id,
                };
                var list = _cart_productManager.GetListCart_productByCart(filter1);
                foreach (Cart_productDto item in list)
                {
                    _cart_productManager.Delete(item.Id);
                }
                return Ok();


            }

            else
            {
                return BadRequest("Некорректный формат ID пользователя.");
            }

        }

        [HttpPost(nameof(DeleteCart_product), Name = nameof(DeleteCart_product))]
        public async Task<ActionResult> DeleteCart_product([FromBody] EditCart_productDto productId)
        {
            _cart_productManager.Delete(productId.Id);
            return Ok();

        }

        #endregion

        #region Employee

        [HttpGet(nameof(Employee), Name = nameof(Employee))]
        public async Task<ActionResult> Employee()
        {
            var employee = _employeeManager.GetListEmployee(new EmployeeFilterDto()).FirstOrDefault();
            return View(employee);
        }

        [HttpPost(nameof(CreatEmployee), Name = nameof(CreatEmployee))]
        public async Task<ActionResult> CreatEmployee([FromBody] EditEmployeeDto employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                //employee.Id = Guid.NewGuid();
                //System.Console.WriteLine("Случайный Guid");
                //System.Console.WriteLine($"doctor: {doctor.IsnNode}\n{doctor.First_Name}\n{doctor.Certificate}\n{doctor.Post}\n{doctor.office}\nend");
                //GetListDoctor();

                _employeeManager.Creat(employee);
                //System.Console.WriteLine($"Случайный Guid:{EmployeeUser.employeeuser.First_Name}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a doctor.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost(nameof(CreatEmployeeView), Name = nameof(CreatEmployeeView))]
        public async Task<ActionResult> CreatEmployeeView([FromBody] EditEmployeeDto employee)
        {
            if (!ModelState.IsValid)
                return View(nameof(employee), employee);
            _employeeManager.Creat(employee);
            return View();
        }

        [HttpPut(nameof(UpdateEmployee), Name = nameof(UpdateEmployee))]
        public async Task<ActionResult> UpdateEmployee([FromBody] EditEmployeeDto employeeDto)
        {
            _employeeManager.Update(employeeDto);
            return Ok();
        }

        [HttpPost(nameof(DeleteEmployee), Name = nameof(DeleteEmployee))]
        public async Task<ActionResult> DeleteEmployee([FromQuery] Guid IsnNode)
        {
            _employeeManager.Delete(IsnNode);
            return Ok();
        }

        [HttpGet(nameof(GetListEmployees), Name = nameof(GetListEmployees))]
        [ServiceFilter(typeof(DevelopmentOnlyFilter))]
        public async Task<ActionResult> GetListEmployees()
        {
            var list = _employeeManager.GetListEmployee(null);
            return View(list);
        }
        #endregion

        #region Feedback

        [HttpGet(nameof(Feedback), Name = nameof(Feedback))]
        public async Task<ActionResult> Feedback()
        {
            var feedback = _feedbackManager.GetListFeedback(new FeedbackFilterDto()).FirstOrDefault();
            return View(feedback);
        }

        [HttpPost(nameof(CreatFeedback), Name = nameof(CreatFeedback))]
        public async Task<ActionResult> CreatFeedback([FromBody] EditFeedbackDto feedback)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                //feedback.Id = Guid.NewGuid();
                //System.Console.WriteLine("Случайный Guid");
                //System.Console.WriteLine($"doctor: {doctor.IsnNode}\n{doctor.First_Name}\n{doctor.Certificate}\n{doctor.Post}\n{doctor.office}\nend");
                //GetListDoctor();

                _feedbackManager.Creat(feedback);
                //System.Console.WriteLine($"Случайный Guid:{FeedbackUser.feedbackuser.First_Name}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a doctor.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost(nameof(CreatFeedbackView), Name = nameof(CreatFeedbackView))]
        public async Task<ActionResult> CreatFeedbackView([FromBody] EditFeedbackDto feedback)
        {
            if (!ModelState.IsValid)
                return View(nameof(feedback), feedback);
            _feedbackManager.Creat(feedback);
            return View();
        }

        [HttpPut(nameof(UpdateFeedback), Name = nameof(UpdateFeedback))]
        public async Task<ActionResult> UpdateFeedback([FromBody] EditFeedbackDto feedbackDto)
        {
            _feedbackManager.Update(feedbackDto);
            return Ok();
        }

        [HttpPost(nameof(DeleteFeedback), Name = nameof(DeleteFeedback))]
        public async Task<ActionResult> DeleteFeedback([FromQuery] Guid IsnNode)
        {
            _feedbackManager.Delete(IsnNode);
            return Ok();
        }

        [HttpGet(nameof(GetListFeedbacks), Name = nameof(GetListFeedbacks))]
        [ServiceFilter(typeof(DevelopmentOnlyFilter))]
        public async Task<ActionResult> GetListFeedbacks()
        {
            var list = _feedbackManager.GetListFeedback(null);
            return View(list);
        }
        #endregion


        #region Product

        [HttpGet(nameof(Product), Name = nameof(Product))]
        public async Task<ActionResult> Product()
        {
            var product = _productManager.GetListProduct(new ProductFilterDto()).FirstOrDefault();
            return View(product);
        }

        [HttpGet(nameof(SearchProduct), Name = nameof(SearchProduct))]
        public async Task<ActionResult<IEnumerable<ProductDto>>> SearchProduct([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Query parameter is required");
            var matchingProducts = _productManager.GetListProduct(null)
                .Where(p => p.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
               .ToArray();
            return Ok(matchingProducts);

        }

        //[HttpGet(nameof(SearchProducts), Name = nameof(SearchProducts))]
        //public Task<ActionResult<IEnumerable<ProductDto>>> SearchProducts([FromQuery] string query)
        //{
        //    if (string.IsNullOrWhiteSpace(query))
        //        return BadRequest("Query parameter is required");

        //    var matchingProducts = _productManager.GetListProduct(null)
        //        .Where(p => p.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
        //        .ToArray();



        [HttpPost(nameof(CreatProduct), Name = nameof(CreatProduct))]
        public async Task<ActionResult> CreatProduct([FromBody] EditProductDto product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                //product.Id = Guid.NewGuid();
                //System.Console.WriteLine("Случайный Guid");
                //System.Console.WriteLine($"doctor: {doctor.IsnNode}\n{doctor.First_Name}\n{doctor.Certificate}\n{doctor.Post}\n{doctor.office}\nend");
                //GetListDoctor();

                _productManager.Creat(product);
                //System.Console.WriteLine($"Случайный Guid:{ProductUser.productuser.First_Name}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a doctor.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost(nameof(CreatProductView), Name = nameof(CreatProductView))]
        public async Task<ActionResult> CreatProductView([FromBody] EditProductDto product)
        {
            if (!ModelState.IsValid)
                return View(nameof(product), product);
            _productManager.Creat(product);
            return View();
        }

        [HttpPut(nameof(UpdateProduct), Name = nameof(UpdateProduct))]
        public async Task<ActionResult> UpdateProduct([FromBody] EditProductDto productDto)
        {
            _productManager.Update(productDto);
            return Ok();
        }

        [HttpPost(nameof(DeleteProduct), Name = nameof(DeleteProduct))]
        public async Task<ActionResult> DeleteProduct([FromQuery] Guid IsnNode)
        {
            _productManager.Delete(IsnNode);
            return Ok();
        }

        [HttpGet(nameof(GetListProducts), Name = nameof(GetListProducts))]
        [ServiceFilter(typeof(DevelopmentOnlyFilter))]
        public async Task<ActionResult<IEnumerable<Product>>> GetListProducts()
        {
            var list = _productManager.GetListProduct(null);
            return Ok(list);
        }

        //[HttpGet(nameof(GetListProducts), Name = nameof(GetListProducts))]
        //[ServiceFilter(typeof(DevelopmentOnlyFilter))]
        //public async Task<ActionResult<IEnumerable<Product>>> GetListProducts()
        //{
        //    var list = _productManager.GetListProduct(null);
        //    return Ok(list);
        //}
        #endregion

        #region Product_property

        [HttpGet(nameof(ImagesForSpailn), Name = nameof(ImagesForSpailn))]
        public async Task<ActionResult<IEnumerable<ImagesForSpailn>>> ImagesForSpailn()
        {
            var product_property = _imagesForSpailnManager.GetListImagesForSpailn(null);
            return Ok(product_property);
        }

        [HttpPost(nameof(CreatProduct_property), Name = nameof(CreatProduct_property))]
        public async Task<ActionResult> CreatProduct_property([FromBody] EditProduct_propertyDto product_property)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                //product_property.Id = Guid.NewGuid();
                //System.Console.WriteLine("Случайный Guid");
                //System.Console.WriteLine($"doctor: {doctor.IsnNode}\n{doctor.First_Name}\n{doctor.Certificate}\n{doctor.Post}\n{doctor.office}\nend");
                //GetListDoctor();

                _product_propertyManager.Creat(product_property);
                //System.Console.WriteLine($"Случайный Guid:{Product_propertyUser.product_propertyuser.First_Name}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a doctor.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost(nameof(CreatProduct_propertyView), Name = nameof(CreatProduct_propertyView))]
        public async Task<ActionResult> CreatProduct_propertyView([FromBody] EditProduct_propertyDto product_property)
        {
            if (!ModelState.IsValid)
                return View(nameof(product_property), product_property);
            _product_propertyManager.Creat(product_property);
            return View();
        }

        [HttpPut(nameof(UpdateProduct_property), Name = nameof(UpdateProduct_property))]
        public async Task<ActionResult> UpdateProduct_property([FromBody] EditProduct_propertyDto product_propertyDto)
        {
            _product_propertyManager.Update(product_propertyDto);
            return Ok();
        }

        [HttpPost(nameof(DeleteProduct_property), Name = nameof(DeleteProduct_property))]
        public async Task<ActionResult> DeleteProduct_property([FromQuery] Guid IsnNode)
        {
            _product_propertyManager.Delete(IsnNode);
            return Ok();
        }

        [HttpGet(nameof(GetListProduct_propertys), Name = nameof(GetListProduct_propertys))]
        [ServiceFilter(typeof(DevelopmentOnlyFilter))]
        public async Task<ActionResult> GetListProduct_propertys()
        {
            var list = _product_propertyManager.GetListProduct_property(null);
            return View(list);
        }

        [HttpGet(nameof(GetListProduct_propertiesByProduct), Name = nameof(GetListProduct_propertiesByProduct))]
        [ServiceFilter(typeof(DevelopmentOnlyFilter))]
        public async Task<ActionResult<IEnumerable<Product_property>>> GetListProduct_propertiesByProduct([FromBody] Guid productId)
        {
            var filter = new Product_propertyByProductFilterDto
            {
                ProductId = productId
            };
            var list = _product_propertyManager.GetListProduct_propertyByProduct(filter);
            return Ok(list);
        }
        #endregion

        #region Sale

        [HttpGet(nameof(Sale), Name = nameof(Sale))]
        public async Task<ActionResult> Sale()
        {
            var sale = _saleManager.GetListSale(new SaleFilterDto()).FirstOrDefault();
            return View(sale);
        }

        [HttpPost(nameof(CreatSale), Name = nameof(CreatSale))]
        public async Task<ActionResult> CreatSale([FromBody] EditSaleDto sale)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                //sale.Id = Guid.NewGuid();
                //System.Console.WriteLine("Случайный Guid");
                //System.Console.WriteLine($"doctor: {doctor.IsnNode}\n{doctor.First_Name}\n{doctor.Certificate}\n{doctor.Post}\n{doctor.office}\nend");
                //GetListDoctor();

                _saleManager.Creat(sale);
                //System.Console.WriteLine($"Случайный Guid:{SaleUser.saleuser.First_Name}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a doctor.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost(nameof(CreatSaleView), Name = nameof(CreatSaleView))]
        public async Task<ActionResult> CreatSaleView([FromBody] EditSaleDto sale)
        {
            if (!ModelState.IsValid)
                return View(nameof(sale), sale);
            _saleManager.Creat(sale);
            return View();
        }

        [HttpPut(nameof(UpdateSale), Name = nameof(UpdateSale))]
        public async Task<ActionResult> UpdateSale([FromBody] EditSaleDto saleDto)
        {
            _saleManager.Update(saleDto);
            return Ok();
        }

        [HttpPost(nameof(DeleteSale), Name = nameof(DeleteSale))]
        public async Task<ActionResult> DeleteSale([FromQuery] Guid IsnNode)
        {
            _saleManager.Delete(IsnNode);
            return Ok();
        }

        [HttpGet(nameof(GetListSales), Name = nameof(GetListSales))]
        [ServiceFilter(typeof(DevelopmentOnlyFilter))]
        public async Task<ActionResult> GetListSales()
        {
            var list = _saleManager.GetListSale(null);
            return View(list);
        }

        [HttpGet(nameof(GetListSalesByProduct), Name = nameof(GetListSalesByProduct))]
        [ServiceFilter(typeof(DevelopmentOnlyFilter))]
        public async Task<ActionResult<IEnumerable<Sale>>> GetListSalesByProduct(Guid productId)
        {

            var list = _saleManager.GetListSale(null);
            return Ok(list);
        }
        #endregion

        #region Season_ticket

        [HttpGet(nameof(Season_ticket), Name = nameof(Season_ticket))]
        public async Task<ActionResult> Season_ticket()
        {
            var season_ticket = _season_ticketManager.GetListSeason_ticket(new Season_ticketFilterDto()).FirstOrDefault();
            return View(season_ticket);
        }

        [HttpPost(nameof(CreatSeason_ticket), Name = nameof(CreatSeason_ticket))]
        public async Task<ActionResult> CreatSeason_ticket([FromBody] EditSeason_ticketDto season_ticket)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                //season_ticket.Id = Guid.NewGuid();
                //System.Console.WriteLine("Случайный Guid");
                //System.Console.WriteLine($"doctor: {doctor.IsnNode}\n{doctor.First_Name}\n{doctor.Certificate}\n{doctor.Post}\n{doctor.office}\nend");
                //GetListDoctor();

                _season_ticketManager.Creat(season_ticket);
                //System.Console.WriteLine($"Случайный Guid:{Season_ticketUser.season_ticketuser.First_Name}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a doctor.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost(nameof(CreatSeason_ticketView), Name = nameof(CreatSeason_ticketView))]
        public async Task<ActionResult> CreatSeason_ticketView([FromBody] EditSeason_ticketDto season_ticket)
        {
            if (!ModelState.IsValid)
                return View(nameof(season_ticket), season_ticket);
            _season_ticketManager.Creat(season_ticket);
            return View();
        }

        [HttpPut(nameof(UpdateSeason_ticket), Name = nameof(UpdateSeason_ticket))]
        public async Task<ActionResult> UpdateSeason_ticket([FromBody] EditSeason_ticketDto season_ticketDto)
        {
            _season_ticketManager.Update(season_ticketDto);
            return Ok();
        }

        [HttpPost(nameof(DeleteSeason_ticket), Name = nameof(DeleteSeason_ticket))]
        public async Task<ActionResult> DeleteSeason_ticket([FromQuery] Guid IsnNode)
        {
            _season_ticketManager.Delete(IsnNode);
            return Ok();
        }

        [HttpGet(nameof(GetListSeason_tickets), Name = nameof(GetListSeason_tickets))]
        [ServiceFilter(typeof(DevelopmentOnlyFilter))]
        public async Task<ActionResult> GetListSeason_tickets()
        {
            var list = _season_ticketManager.GetListSeason_ticket(null);
            return View(list);
        }
        #endregion
        #region Sale_product_property

        [HttpPost(nameof(CreatSale_product_property), Name = nameof(CreatSale_product_property))]
        public async Task<ActionResult> CreatSale_product_property([FromBody] EditSale_product_propertyDto sale_product_property)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                //sale_product_property.Id = Guid.NewGuid();
                //System.Console.WriteLine("Случайный Guid");
                //System.Console.WriteLine($"doctor: {doctor.IsnNode}\n{doctor.First_Name}\n{doctor.Certificate}\n{doctor.Post}\n{doctor.office}\nend");
                //GetListDoctor();

                _sale_product_propertyManager.Creat(sale_product_property);
                //System.Console.WriteLine($"Случайный Guid:{Sale_product_propertyUser.sale_product_propertyuser.First_Name}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a doctor.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet(nameof(GetListSale_product_propertys), Name = nameof(GetListSale_product_propertys))]
        [ServiceFilter(typeof(DevelopmentOnlyFilter))]
        public async Task<ActionResult> GetListSale_product_propertys()
        {
            var list = _sale_product_propertyManager.GetListSale_product_property(null);
            return View(list);
        }

        [HttpGet(nameof(GetListSale_product_propertiesBySale), Name = nameof(GetListSale_product_propertiesBySale))]
        [ServiceFilter(typeof(DevelopmentOnlyFilter))]
        public async Task<ActionResult<IEnumerable<Sale_product_property>>> GetListSale_product_propertiesBySale(Guid saleid)
        {
            var filter = new SaleFilterDto { Id = saleid };
            var list = _sale_product_propertyManager.GetListSale_product_propertyBySale(filter);
            return Ok(list);
        }

        #endregion

        public class AdmissionRequest
        {
            public ClientDto Client { get; set; }
            public ProductDto Product { get; set; }
            public DateTime Time { get; set; }
            public EmployeeDto Employee { get; set; }
        }

        public class Cart_for_front
        {
            public Guid Id { get; set; }
            public Guid ProductId { get; set; }

            public Guid CartId { get; set; }

            public double count { get; set; }

            public string Name { get; set; }

            public double Price { get; set; }
        }

        public class Product_for_search
        {
            public string Name { get; set; }
            public double Price { get; set; }


        }

        [HttpPost(nameof(SearchAccount), Name = nameof(SearchAccount))]

        public ClientDto SearchAccount(string Telephone, string Email)
        {
            var list = _clientManager.GetListClient(null);
            foreach (var item in list)
            {
                if (Telephone == item.Telephone || Email == item.Email)
                {
                    return item;
                }
            }
            return null;
        }

    }
}

