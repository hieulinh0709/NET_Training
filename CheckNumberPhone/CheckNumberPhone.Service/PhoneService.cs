﻿using FindBeeNumbers.Core.Entities;
using FindBeeNumbers.Core.Model;
using FindBeeNumbers.Repository.IRepository;
using FindBeeNumbers.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindBeeNumbers.Service
{
    /// <summary>
    /// PhoneService
    /// </summary>
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;

        public PhoneService(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        #region method
        /// <summary>
        /// Get all number phone
        /// </summary>
        /// <returns></returns>
        public async Task<List<Phone>> GetAllPhones()
        {
            var list = await _phoneRepository.GetAllPhones();
            return list;
        }

        /// <summary>
        /// Checked phone number list
        /// </summary>
        /// <param name="phones"></param>
        /// <param name="bee"></param>
        /// <returns></returns>
        public List<Phone> ListNumberPhoneChecked(List<Phone> phones, Bee bee)
        {
            
            List<Phone> phonesChecked = new List<Phone>();

            if (phones == null)
            {
                return phonesChecked;
            }

            foreach (var phone in phones)
            {
               var isBee = IsBeeNumber(bee, phone);
                if (isBee)
                {
                    phonesChecked.Add(phone);
                }    
            }

            return phonesChecked;
        }

        /// <summary>
        /// Is Bee Number
        /// </summary>
        /// <param name="bee"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool IsBeeNumber(Bee bee, Phone phone)
        {
            var providerNetworkFromBee = bee.Providers;
            var twoLastNumberTabooFromBee = bee.TabooNumbers;
            var twoLastNumberNiceFromBee = bee.NiceNumbers;

            if (string.IsNullOrEmpty(phone.Number))
            {
                return false;
            }

            // check phone number length 
            if (phone.Number.Length == bee.Limit)
            {
                var twoLastNumber = phone.Number.Substring(phone.Number.Length - 2);

                // Check provider network
                if ( IsProviderNetwork(phone, providerNetworkFromBee))
                {
                    // The last 2 num chars is taboo
                    if (Array.Exists(twoLastNumberTabooFromBee, element => element.Equals(twoLastNumber)))
                    {
                        return false;
                    }
                    else
                    {
                        // Total first 5 nums / Total last 5 nums: matches 1 in n conditions configuratin into Bee.json
                        if (IsTotal5NumberFirstAndLast(phone.Number, bee.SumOfNumbers) &&
                            Array.Exists(twoLastNumberNiceFromBee, element => element.Equals(twoLastNumber)))
                        {
                            return true;
                        };
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check Provider Network
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="providersBee"></param>
        /// <returns></returns>
        public bool IsProviderNetwork(Phone phone, List<Provider> providersBee)
        {
            var providerNetwork = phone.Network;
            var threeFirstNumber = phone.Number.Substring(0, 3);

            if (providersBee != null)
            {
                foreach (var provider in providersBee)
                {
                    if (provider.Name.Equals(providerNetwork))
                    {
                        return Array.Exists(provider.Prefixes, element => element.Equals(threeFirstNumber));
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check Total 5 Number First And Last
        /// </summary>
        /// <param name="numberPhone"></param>
        /// <param name="sumOfNumbers"></param>
        /// <returns></returns>
        public bool IsTotal5NumberFirstAndLast(string numberPhone, List<SumOfNumbers> sumOfNumbers)
        {
            int total5NumberFirst = 0;
            int total5NumberLast = 0;

            total5NumberFirst = numberPhone.Substring(0, 5).Select(x => Int32.Parse(x.ToString())).Sum();

            total5NumberLast = numberPhone.Substring(5, 5).Select(x => Int32.Parse(x.ToString())).Sum();

            foreach (var pair in sumOfNumbers)
            {
                if (total5NumberFirst == Convert.ToInt16(pair.FromFirst) && total5NumberLast == Convert.ToInt16(pair.FromLast))
                    return true;
            }
            return false;
        }
        #endregion method
    }
}
