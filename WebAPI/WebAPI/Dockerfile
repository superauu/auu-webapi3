FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 9999

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY Auu.WebAPI/Ms.WebAPI.csproj Auu.WebAPI/
COPY Auu.Common/Ms.Framework.Common.csproj Auu.Common/
COPY Auu.DLR/Ms.Framework.DLR.csproj Auu.DLR/
COPY Auu.WebAPI.MiddleWare/Ms.WebAPI.MiddleWare.csproj Auu.WebAPI.MiddleWare/
COPY Auu.Controllers.NugetImort/Ms.Controllers.Base.csproj Auu.Controllers.NugetImort/
COPY Auu.DbController/Ms.Framework.DbController.csproj Auu.DbController/
COPY Auu.Models.SystemModel/Ms.Models.SystemModel.csproj Auu.Models.SystemModel/
COPY Auu.Controllers.SystemController/Ms.Controllers.SystemController.csproj Auu.Controllers.SystemController/
COPY Auu.Workflow/Ms.Framework.Workflow.csproj Auu.Workflow/
COPY Auu.Notification/Ms.Framework.Notification.csproj Auu.Notification/
COPY Auu.AliyunApi/Ms.Framework.AliyunApi.csproj Auu.AliyunApi/
RUN dotnet restore
COPY . .
WORKDIR /src/Ms.WebAPI
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ms.WebAPI.dll"]
