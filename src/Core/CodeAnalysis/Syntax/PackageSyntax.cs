﻿// <copyright file="PackageSyntax.cs" company="GSharp">
// Copyright (C) GSharp Authors. All rights reserved.
// </copyright>

namespace GSharp.Core.CodeAnalysis.Syntax
{
    using System.Collections.Immutable;
    using System.Linq;

    /// <summary>
    /// Represents a package declaration in the language.
    /// </summary>
    public sealed class PackageSyntax : MemberSyntax
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PackageSyntax"/> class.
        /// </summary>
        /// <param name="packageKeyword">The package keyword.</param>
        /// <param name="identifiers">The package identifiers.</param>
        public PackageSyntax(
            SyntaxToken packageKeyword,
            ImmutableArray<SyntaxToken> identifiers)
        {
            PackageKeyword = packageKeyword;
            IdentifiersWithDots = identifiers;
            Identifiers = identifiers.Where(t => t.Kind == SyntaxKind.IdentifierToken).ToImmutableArray();
        }

        /// <inheritdoc/>
        public override SyntaxKind Kind => SyntaxKind.PackageDeclaration;

        /// <summary>
        /// Gets the package keyword.
        /// </summary>
        public SyntaxToken PackageKeyword { get; }

        /// <summary>
        /// Gets the package identifiers, excluding dots.
        /// </summary>
        public ImmutableArray<SyntaxToken> Identifiers { get; }

        /// <summary>
        /// Gets the package identifiers, including dots.
        /// </summary>
        public ImmutableArray<SyntaxToken> IdentifiersWithDots { get; }
    }
}
