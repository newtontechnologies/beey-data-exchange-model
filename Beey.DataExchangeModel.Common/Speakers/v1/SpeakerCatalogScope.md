# SpeakerCatalog scopes

Purpose of scope is to allow multitenancy for speaker catalog.

WARNING: The current implementation is likely to change in the future, please keep it on mind.

While a [scope](SpeakerCatalogScope.cs) describes a context in which a speaker is valid, currently every speaker is valid only for a specific tenant.

## Rules of current implementation

NOTE: These rules apply to SpeakerCatalog API; Beey autorization can add more strict rules if needed

* Each speaker fits into a single scope.
* There is a global default scope which is meant for shared speakers.
* When listing speakers you can read from a specific scope *OR* across all scopes.
* Once speaker is created, it cannot be moved into another scope. If this is needed, a new operation must be implemented for this.
* **Tenant id currently matches to user's team Id**. This means that speakers are per-team.
