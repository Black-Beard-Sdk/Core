using System;

namespace Bb.Mapping
{

    public interface IMapper<TEntity, TExposed> : IMapper
    {

        TEntity Map(TExposed source, TEntity target);

        TExposed Map(TEntity source, TExposed target);

    }

    public interface IMapper
    {

        Type Source { get; }

        Type Target { get; }

        /// <summary>
        /// return true if accepts the specified type source to map in target type.
        /// </summary>
        /// <param name="typeSource">The type source.</param>
        /// <param name="typeTarget">The type target.</param>
        /// <returns></returns>
        bool Accept(Type typeSource, Type typeTarget);

        /// <summary>
        /// Maps the specified source in target.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        object Map(object source, object target);

    }
}