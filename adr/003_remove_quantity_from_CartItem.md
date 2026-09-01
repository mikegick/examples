# Remove Quantity from CartItem

## Status

Completed

## Context

CartItem is currently acting as both metadata about a product, as well as metadata for a specific user's shopping cart.

## Decision

Bifurcate CartItem into Product and ShoppingCart in order to adhere to SRP.

## Consequences

- Separation of concerns results in reduced cognitive load
- Easier testing and maintenance