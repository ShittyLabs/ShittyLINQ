# Contributing to ShittyLINQ

1. Read the [Code of Conduct](./CODE_OF_CONDUCT.md)
1. If adding a new method, follow the [new method instructions](#adding-a-new-method)

## Adding a new method
1. If an issue exists for this method, add a comment to let everyone know that you are implementing it. This helps us avoid duplicates.
1. Fork the repo if you haven't done so already.
1. Create a branch from an up-to-date `develop` branch.
1. Add a file at `./ShittyLINQ/<method name>.cs`.
1. Add the new `public static` method in a `public static partial` class called `Extensions`, which must be in the `ShittyLINQ` namespace.
1. Implement the method.
1. Document the method using standard XML documentation.
1. [Add tests](#adding-a-set-of-tests).
1. Push branch to your fork.
1. Create a pull request against the `develop` branch of the main repo.

## Adding a set of tests
1. Add a file at `./ShittyLinqTests/<method name>Tests.cs`.
1. Inside of the `ShittyTests` namespace, add your test methods.
1. Add tests for success conditions.
1. Add tests for failure conditions according to the MSDN documents for the method you are adding. Ensure the proper exceptions are thrown.
