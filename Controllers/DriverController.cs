using DriverCrudTestApi.Helpers.HelperModels;
using DriverCrudTestApi.Services.Commands.Interfaces;
using DriverCrudTestApi.Services.Queries.Interfacses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DriverCrudTestApi.Controllers
{
	/// <summary>
	/// manages all Driver operations
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class DriverController : ControllerBase
	{
		private readonly ICreateDriverCommand _createDriverCommand;
		private readonly IUpdateDriverCommand _updateDriverCommand;
		private readonly IDeleteDriverCommand _deleteDriverCommand;
		private readonly IGetDriverDetailsQuery _getDriverDetailsQuery;
		private readonly IGetDriverListQuery _getDriverListQuery;

		public DriverController(ICreateDriverCommand createDriverCommand,IUpdateDriverCommand updateDriverCommand,IDeleteDriverCommand deleteDriverCommand,
								IGetDriverDetailsQuery getDriverDetailsQuery,IGetDriverListQuery getDriverListQuery) 
								{
									_createDriverCommand= createDriverCommand;
									_updateDriverCommand= updateDriverCommand;
									_deleteDriverCommand= deleteDriverCommand;
									_getDriverDetailsQuery= getDriverDetailsQuery;
									_getDriverListQuery= getDriverListQuery;
								}

		/// <summary>
		/// Add new driver 
		/// </summary>
		/// <param name="model"></param>
		/// <remarks>
		/// 
		///	Request Sample :
		/// 
		///		{
		///			"FirstName": "hamida",
		///			"LastName": "hamida",
		///			"Email": "ham@ham.ham",
		///			"PhoneNumber": "01001239474"
		///			
		///		}
		///		
		/// Response Sample:
		/// 
		/// 
		///	Status Code: 400 BadRequest if first name is empty or null
		/// 
		///     {
		///      
		///      "ErrorMessage" : "The name is empty or null."
		///     }
		///     
		/// Status Code: 400 BadRequest if first name is invalid
		/// 
		///     {
		///      
		///      "ErrorMessage" : "Invalid first name."
		///     }
		///     
		/// Status Code: 400 BadRequest if last name is empty or null
		/// 
		///     {
		///      
		///      "ErrorMessage" : "The last name is empty or null."
		///     }
		///     
		/// Status Code: 400 BadRequest if last name i invalid
		/// 
		///     {
		///      
		///      "ErrorMessage" : "Invalid last name."
		///     }
		///     
		/// Status Code: 400 BadRequest if email is empty or null
		/// 
		///     {
		///      
		///      "ErrorMessage" : "The Email address is empty or null."
		///     }
		/// 
		///	Status Code: 400 BadRequest if email is invalid format
		/// 
		///     {
		///      
		///      "ErrorMessage" : "Invalid email address name, it must be like h@h.com."
		///     }
		///     
		/// Status Code: 400 BadRequest if phone number is empty or null
		/// 
		///     {
		///      
		///      "ErrorMessage" : "The Phone number is empty or null."
		///     }
		///     
		/// Status Code: 400 BadRequest if phone number is invalid
		/// 
		///     {
		///      
		///      "ErrorMessage" : "Invalid Phone number."
		///     }
		///	
		/// 
		/// Status Code: 500 BadRequest if server error occured
		/// 
		///     {
		///      
		///      "ErrorMessage" : "An error occured while processing your request :"
		///     }
		///		
		/// Status Code: 200 ok if success
		/// 
		///     {
		///			1
		///     }
		/// </remarks>
		/// <returns></returns>
		[Route("Create")]
		[HttpPost]
		public IActionResult AddDriver([FromBody] CreateDriverRequestModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var response = _createDriverCommand.Create(model);
					if (response.HasError)
					{
						return StatusCode((int)HttpStatusCode.BadRequest,
						 response.ErrorMessage);
					}
					else
						return StatusCode((int)HttpStatusCode.OK,
								response.Data);
				}
				else
				{
					return StatusCode((int)HttpStatusCode.BadRequest,
						ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.InvalidModel));

				}

			}
			catch (Exception ex)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError,
						ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.internalServerError) //+ ex.Message
	);

			}

		}
		/// <summary>
		/// update  driver data
		/// </summary>
		/// <param name="model"></param>
		/// <remarks>
		/// 
		///	Request Sample :
		/// 
		///		{
		///			"Id":1,
		///			"FirstName": "hamida",
		///			"LastName": "hamida",
		///			"Email": "ham@ham.ham",
		///			"PhoneNumber": "01001239474"
		///			
		///		}
		///		
		/// Response Sample:
		/// 
		/// 
		/// 
		///	Status Code: 400 BadRequest if first name is empty or null
		/// 
		///     {
		///      
		///      "ErrorMessage" : "The name is empty or null."
		///     }
		///     
		/// Status Code: 400 BadRequest if first name is invalid
		/// 
		///     {
		///      
		///      "ErrorMessage" : "Invalid first name."
		///     }
		///     
		/// Status Code: 400 BadRequest if last name is empty or null
		/// 
		///     {
		///      
		///      "ErrorMessage" : "The last name is empty or null."
		///     }
		///     
		/// Status Code: 400 BadRequest if last name i invalid
		/// 
		///     {
		///      
		///      "ErrorMessage" : "Invalid last name."
		///     }
		///     
		/// Status Code: 400 BadRequest if email is empty or null
		/// 
		///     {
		///      
		///      "ErrorMessage" : "The Email address is empty or null."
		///     }
		/// 
		///	Status Code: 400 BadRequest if email is invalid format
		/// 
		///     {
		///      
		///      "ErrorMessage" : "Invalid email address name, it must be like h@h.com."
		///     }
		///     
		/// Status Code: 400 BadRequest if phone number is empty or null
		/// 
		///     {
		///      
		///      "ErrorMessage" : "The Phone number is empty or null."
		///     }
		///     
		/// Status Code: 400 BadRequest if phone number is invalid
		/// 
		///     {
		///      
		///      "ErrorMessage" : "Invalid Phone number."
		///     }
		///	
		/// 
		/// Status Code: 500 BadRequest if server error occured
		/// 
		///     {
		///      
		///      "ErrorMessage" : "An error occured while processing your request :"
		///     }
		///		
		/// Status Code: 200 ok if success
		/// 
		///     {
		///			1
		///     }
		/// </remarks>
		/// <returns></returns>
		[Route("Update")]
		[HttpPut]
		public IActionResult UpdateDrivert([FromBody] UpdateDriverRequestModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var response = _updateDriverCommand.Update(model);
					if (response.HasError)
					{
						return StatusCode((int)HttpStatusCode.BadRequest,
						 response.ErrorMessage);
					}
					else
						return StatusCode((int)HttpStatusCode.OK,
							response.Data
							);
				}
				else
				{
					return StatusCode((int)HttpStatusCode.BadRequest,
						ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.InvalidModel));

				}

			}
			catch (Exception ex)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError,
						 ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.internalServerError)); //+ ex.Message);

			}
		}

		/// <summary>
		/// gets all the drivers
		/// </summary>
		/// <remarks>
		/// Response Sample:
		///
		/// Status Code: 500 BadRequest if server error occured
		/// 
		///     {
		///      
		///      "ErrorMessage" : "An error occured while processing your request :"
		///     }
		///		
		/// Status Code: 200 ok if success
		/// 
		///			{
		///				[
		///					{
		///						"Id":1,
		///						"FirstName": "hamida",
		///						"LastName": "hamida",
		///						"Email": "ham@ham.ham",
		///						"PhoneNumber": "01001239474",
		///    					"CreationDate": "2022-05-14T12:15:41.8348553",
		///    					"CreatedBy":3,
		///    					"DeletedDate":"2022-06-14T12:15:41.8348553",
		///    					"DeletedBy":4,
		///   					"UpdatedDate": null,
		///   					UpdatedBy:null
		///   				},
		///   				
		///					{
		///						"Id":2,
		///						"FirstName": "Amany",
		///						"LastName": "Amany",
		///						"Email": "am@am.ham",
		///						"PhoneNumber": "01007639474",
		///    					"CreationDate": "2022-05-14T12:15:41.8348553",
		///    					"CreatedBy":3,
		///    					"DeletedDate":"2022-06-14T12:15:41.8348553",
		///    					"DeletedBy":4,
		///   					"UpdatedDate": null,
		///   					UpdatedBy:null
		///   				}
		///    			]
		/// 
		///			}
		/// 		 
		///     
		/// </remarks>
		/// <returns></returns>
		[Route("GetAll")]
		[HttpGet]
		public IActionResult GetAll()
		{
			try
			{
				var response = _getDriverListQuery.GetDriverList();
				if (response.HasError)
				{
					return StatusCode((int)HttpStatusCode.BadRequest,

							 response.ErrorMessage);
				}
				else
				{
					return StatusCode((int)HttpStatusCode.OK,
						response.Data

						);
				}
			}
			catch (Exception ex)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError,
						 ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.internalServerError));// + ex.Message);
			}
		}

		/// <summary>
		/// Get driver by Id
		/// </summary>
		/// <remarks>
		/// 
		/// Request Sample:
		/// 
		///		{
		///				"DriverId":1
		///		}
		///
		/// Response Sample:
		/// 
		/// Status Code: 400 BadRequest if Id is not valid
		/// 
		///     {
		///      
		///      "ErrorMessage" : "Invalid Id, it must be provided and greater than 0."
		///     }
		///
		/// 
		/// Status Code: 400 BadRequest if no applicant was found with the given Id
		/// 
		///     {
		///      
		///      "ErrorMessage" : "This driver is not exist."
		///     }
		///
		/// 
		/// Status Code: 500 BadRequest if server error occured
		/// 
		///     {
		///      
		///      "ErrorMessage" : "An error occured while processing your request :"
		///     }
		///		
		/// 
		/// Status Code: 200 ok if success
		/// 
		///			{
		///			     "FirstName": "hamida",
		///  			 "LastName": "hamida",
		/// 			 "PhoneNumber": "01006547897",
		///   			 "Email": "ham@ham.ham",
		///				 "Id": 1,
		///    			 "CreationDate": "2022-05-14T12:15:41.8348553",
		///    		     "CreatedBy":3,
		///    		     "DeletedDate":"2022-06-14T12:15:41.8348553",
		///    		     "DeletedBy":4,
		///   		     "UpdatedDate": null,
		///   		     UpdatedBy:null
		///    		}
		///     
		/// 
		/// </remarks>
		/// <param name="driverId"></param>
		/// <returns></returns>
		[Route("GetDetails")]
		[HttpGet]
		public IActionResult GetById(long driverId)
		{
			try
			{
				var response = _getDriverDetailsQuery.GetDriverDetails(driverId);
				if (response.HasError)
				{
					return StatusCode((int)HttpStatusCode.BadRequest,
						response.ErrorMessage);
				}
				else
				{
					return StatusCode((int)HttpStatusCode.OK,
						response.Data);
				}
			}
			catch (Exception ex)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError,
						ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.internalServerError));// + ex.Message);
			}
		}

		/// <summary>
		/// Delete driver
		/// </summary>
		/// <remarks>
		/// 
		/// Request Sample:
		/// 
		///		{
		///				"DriverId":1
		///		}
		///
		/// Response Sample:
		/// 
		/// 
		/// Status Code: 400 BadRequest if no applicant was found with the given Id
		/// 
		///     {
		///      
		///      "ErrorMessage" : "This driver is not exist."
		///     }
		///
		/// Status Code: 400 BadRequest if DriverId is not valid
		/// 
		///     {
		///      
		///      "ErrorMessage" : "Invalid Id, it must be provided and greater than 0."
		///     }
		///
		/// 
		/// Status Code: 500 BadRequest if server error occured
		/// 
		///     {
		///      
		///      "ErrorMessage" : "An error occured while processing your request :"
		///     }
		///		
		/// 
		/// Status Code: 200 ok if success
		/// 
		///     {
		///			 true
		///     }
		///     
		/// 
		/// </remarks>
		/// <param name="driverId"></param>
		/// <returns></returns>

		[Route("Delete")]
		[HttpDelete]
		public IActionResult DeleteApplicant(long driverId)
		{
			try
			{
				var response = _deleteDriverCommand.Delete(driverId);
				if (response.HasError)
				{
					return StatusCode((int)HttpStatusCode.BadRequest,
						 response.ErrorMessage);
				}
				else
				{
					return StatusCode((int)HttpStatusCode.OK,
						 response.Data);
				}
			}
			catch (Exception ex)
			{
				return StatusCode((int)HttpStatusCode.InternalServerError,
						ErrorMessageGenerator.GenerateErrorMessage(ErrorMessageGeneratorEnum.internalServerError));// + ex.Message);
			}
		}

	}
}
