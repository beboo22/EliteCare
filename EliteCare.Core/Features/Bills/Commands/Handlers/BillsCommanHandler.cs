using AutoMapper;
using EliteCare.Core.Features.Bills.Commands.Models;
using EliteCare.Data.Entities;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Bills.Commands.Handlers
{
    public class BillsCommanHandler : IRequestHandler<AddBillCommand, ApiResponse>,
                                        IRequestHandler<CallBackCommand, ApiResponse>
    {
        IBookingService _bookingService;
        IMapper mapper;

        public BillsCommanHandler(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> Handle(AddBillCommand request, CancellationToken cancellationToken)
        {
            var MappedBill = mapper.Map<Bill>(request.billDto);

            return await  _bookingService.Book(MappedBill);
        }

        public async Task<ApiResponse> Handle(CallBackCommand request, CancellationToken cancellationToken)
        {
           return await _bookingService.HandlePaymobCallback(request.element);
        }
    }
}
