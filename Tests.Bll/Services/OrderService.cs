using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Tests.Dal.Contexts;
using Tests.Dal.Models;

namespace Tests.Bll.Services
{
    public class OrderService
    {
        public MainContext _context;
        public OrderService(MainContext context)
        {
            _context = context;
        }


        public async void CreateOrder(int subscriptionTypeId, int amount, int userId)
        {
            SubscriptionType subscriptionType = await _context.SubscriptionType.Include(x => x.LongevityType).FirstOrDefaultAsync(x => x.Id == subscriptionTypeId);
            List<DiscountType> discountTypes = await _context.DiscountType.Where(x => x.BreakpointSubscriptionTypeId == subscriptionType.Id).ToListAsync();
            DiscountType currentDiscountType = null;
            if(discountTypes.Count > 0)
            {
                for (int i = 0; i < discountTypes.Count; i++)
                {
                    if(discountTypes[i].BreakpointLongevityValue <= amount)
                    {
                        currentDiscountType = discountTypes[i];
                    }   
                }
            }
            decimal discountProcent = 1;
            if (currentDiscountType != null)
            {
                if (currentDiscountType.IsAccumulative == true)
                {
                    discountProcent = discountProcent - amount / currentDiscountType.BreakpointLongevityValue * currentDiscountType.DiscountValue;
                }
                else
                {
                    discountProcent = discountProcent - currentDiscountType.DiscountValue;
                }
            }
            decimal totalPrice = (subscriptionType.Price * amount) * discountProcent;
            DateTime currentTime = DateTime.UtcNow;
            DateTime beginTime = DateTime.UtcNow;
            List<Subscription> subscriptions = new List<Subscription>();
            for(int i = 0; i < amount; i++)
            {
                DateTime endTime;
                if(subscriptionType.LongevityType.LongevityMeasureName == "Month")
                {
                    endTime = beginTime.AddMonths(subscriptionType.LongevityType.LongevityValue);
                }
                if (subscriptionType.LongevityType.LongevityMeasureName == "Day")
                {
                    endTime = beginTime.AddDays(subscriptionType.LongevityType.LongevityValue);
                }
                if (subscriptionType.LongevityType.LongevityMeasureName == "Month")
                {
                    endTime = beginTime.AddYears(subscriptionType.LongevityType.LongevityValue);
                }
                Subscription subscription = new Subscription()
                {
                    TypeId = subscriptionType.Id,
                    UserId = userId,
                    CreatedDateTime = currentTime,
                    BeginDateTime = beginTime,
                    EndDateTime = endTime,
                }
            }
        }
    }
}
