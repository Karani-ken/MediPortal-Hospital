using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using MediPortal_Hospital.Models;
using MediPortal_Hospital.Models.Dtos;
using MediPortal_Hospital.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediPortal_Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        private readonly IHospitalInterface _hospitalInterface;
        private readonly BlobServiceClient _blobServiceClient;
        public HospitalController(IMapper mapper, IHospitalInterface hospitalInterface, BlobServiceClient blobServiceClient)
        {
            _mapper = mapper;
            _hospitalInterface = hospitalInterface;
            _response = new ResponseDto();
            _blobServiceClient = blobServiceClient;
        }

        //Add Hospital
        [HttpPost]
      //   [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseDto>> AddHospital( HospitalRequestDto hospitalRequestDto)
        {
            var newHospital = _mapper.Map<Hospital>(hospitalRequestDto);
            try
            {               
                var res = await _hospitalInterface.AddHospital(newHospital);
                if (string.IsNullOrWhiteSpace(res))
                {
                    _response.IsSuccess = false;
                    _response.Message = "something went wrong";

                    return BadRequest(_response);
                }

                return Ok(_response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        //Get hospitals
        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetHospitals()
        {
            try
            {
                var res = await _hospitalInterface.GetHospitals();
                if (res == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Could not fetch hospitals";
                    return BadRequest(_response);
                }
                _response.obj = res;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        //Update Hospital
        [HttpPut]

        public async Task<ActionResult<ResponseDto>> UpdateHospitals( HospitalRequestDto hospitalRequestDto, Guid Id)
        {
            try
            {
                var AllHospitals = await _hospitalInterface.GetHospitals();
                var hospitalToUpdate = AllHospitals.FirstOrDefault(h => h.HospitalId == Id);
                if (hospitalToUpdate == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Hospital was not found";
                    return BadRequest(_response);
                }
                var UpdatedHospital = _mapper.Map(hospitalRequestDto, hospitalToUpdate);
                var res = await _hospitalInterface.UpdateHospital(UpdatedHospital);
                _response.obj = res;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        //Delete a hospital
        [HttpDelete]
       
        public async Task<ActionResult<ResponseDto>> DeleteHospitals(Guid Id)
        {
            try
            {
                var AllHospitals = await _hospitalInterface.GetHospitals();
                var hospitalToDelete = AllHospitals.FirstOrDefault(h => h.HospitalId == Id);
                if (hospitalToDelete == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Hospital was not found";
                    return BadRequest(_response);
                }

                var res = await _hospitalInterface.DeleteHospital(hospitalToDelete);
                _response.obj = res;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        //get a single hospital by id
        [HttpGet("ById")]
        public async Task<ActionResult<ResponseDto>> GetHospitalById(Guid Id)
        {
            try
            {
                var Hospital = await _hospitalInterface.GetHospitalById(Id);
                if (Hospital == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Hospital was not found";
                    return BadRequest(_response);
                }

               
                _response.obj = Hospital;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
    }
}
