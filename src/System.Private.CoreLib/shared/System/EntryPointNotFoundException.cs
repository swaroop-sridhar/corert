// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

/*=============================================================================
**
**
**
** Purpose: The exception class for some failed P/Invoke calls.
**
**
=============================================================================*/

using System;
using System.Runtime.Serialization;

namespace System
{
    public class EntryPointNotFoundException : TypeLoadException
    {
        public EntryPointNotFoundException()
            : base(SR.Arg_EntryPointNotFoundException)
        {
            HResult = __HResults.COR_E_ENTRYPOINTNOTFOUND;
        }

        public EntryPointNotFoundException(String message)
            : base(message)
        {
            HResult = __HResults.COR_E_ENTRYPOINTNOTFOUND;
        }

        public EntryPointNotFoundException(String message, Exception inner)
            : base(message, inner)
        {
            HResult = __HResults.COR_E_ENTRYPOINTNOTFOUND;
        }

        protected EntryPointNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            throw new PlatformNotSupportedException();
        }
    }
}
