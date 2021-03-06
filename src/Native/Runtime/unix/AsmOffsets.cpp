// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
#ifdef _ARM_

#define PLAT_ASM_OFFSET(offset, cls, member) OFFSETOF__##cls##__##member 0x##offset
#define PLAT_ASM_SIZEOF(size,   cls        ) SIZEOF__##cls 0x##size
#define PLAT_ASM_CONST(constant, expr)       expr 0x##constant

#else

#define PLAT_ASM_OFFSET(offset, cls, member) .set OFFSETOF__##cls##__##member, 0x##offset
#define PLAT_ASM_SIZEOF(size,   cls        ) .set SIZEOF__##cls, 0x##size
#define PLAT_ASM_CONST(constant, expr)       .set expr, 0x##constant

#endif

#include <AsmOffsets.h>
