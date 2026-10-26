FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY project/ ./project/
RUN project="$(find ./project -maxdepth 1 -name '*.csproj' -print -quit)" \
    && test -n "$project" \
    && dotnet publish "$project" -c Release -o /out \
    && app="$(find /out -maxdepth 1 -name '*.runtimeconfig.json' -printf '%f\n' | head -n 1 | sed 's/\.runtimeconfig\.json$/.dll/')" \
    && test -n "$app" \
    && printf '%s' "$app" > /out/startup.txt

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out/ .
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080
ENTRYPOINT ["sh", "-c", "exec dotnet \"$(cat /app/startup.txt)\""]
