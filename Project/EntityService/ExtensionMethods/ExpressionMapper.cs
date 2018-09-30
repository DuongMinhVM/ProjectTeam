﻿using System;
using System.Linq.Expressions;

namespace EntityService.ExtensionMethods
{
    public static class ExpressionMapper
    {
        public static Expression<Func<TX, TY>> Compose<TX, TY, TZ>(this Expression<Func<TZ, TY>> outer, Expression<Func<TX, TZ>> inner)
        {
            return Expression.Lambda<Func<TX, TY>>(
                ParameterReplacer.Replace(outer.Body, outer.Parameters[0], inner.Body),
                inner.Parameters[0]);
        }
    }
}