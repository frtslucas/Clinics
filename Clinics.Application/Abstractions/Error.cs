﻿using Clinics.Domain.Abstractions;

namespace Clinics.Application.Abstractions
{
    public class Error : Enumeration
    {
        public static Error NotFound = new(ErrorEnum.NotFound, nameof(NotFound));
        public static Error InvalidRequest = new(ErrorEnum.InvalidRequest, nameof(InvalidRequest));
        public static Error InternalError = new(ErrorEnum.InternalError, nameof(InternalError));

        private Error(ErrorEnum value, string name) : base((int)value, name)
        {
        }

        private enum ErrorEnum
        {
            NotFound,
            InvalidRequest,
            InternalError
        }
    }
}
