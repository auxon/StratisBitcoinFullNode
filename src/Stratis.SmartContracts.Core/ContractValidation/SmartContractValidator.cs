﻿using System.Collections.Generic;

namespace Stratis.SmartContracts.Core.ContractValidation
{
    public sealed class SmartContractValidator
    {
        private readonly IList<ISmartContractValidator> validators;

        public SmartContractValidator(IList<ISmartContractValidator> validators)
        {
            this.validators = validators;
        }

        public SmartContractValidationResult ValidateContract(SmartContractDecompilation decompilation)
        {
            var endResult = new SmartContractValidationResult();
            foreach (ISmartContractValidator validator in this.validators)
            {
                SmartContractValidationResult result = validator.Validate(decompilation);
                endResult.Errors.AddRange(result.Errors);
            }
            return endResult;
        }
    }
}