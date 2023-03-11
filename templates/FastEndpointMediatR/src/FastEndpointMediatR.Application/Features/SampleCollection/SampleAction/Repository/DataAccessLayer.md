Inject services or repositories in the handler class or write vertical slice repo under the Action namespace.

You could also provide the Domain objects under the Action namespace in a vertical slice style.

Last but not least, if micro ORM (e.g. Dapper) is preferred, then write the corresponding repo under the Repository namespace.