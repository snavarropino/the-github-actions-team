resource "azurerm_resource_group" "zerorg" {
  name     = var.resource_group
  location = var.location
}

resource "azurerm_application_insights" "heroesappinsights" {
  name                = var.heroesinsights
  location            = azurerm_resource_group.zerorg.location
  resource_group_name = azurerm_resource_group.zerorg.name
  application_type    = "Web"
}

resource "azurerm_app_service_plan" "zerosp" {
  name                = var.app_service_plan_name
  location            = azurerm_resource_group.zerorg.location
  resource_group_name = azurerm_resource_group.zerorg.name

  sku {
    tier = "Standard"
    size = "S1"
  }
}

## Api App Service
resource "azurerm_app_service" "heroesapi" {
  name                = var.heroesapi_appsvcname
  location            = azurerm_resource_group.zerorg.location
  resource_group_name = azurerm_resource_group.zerorg.name
  app_service_plan_id = azurerm_app_service_plan.zerosp.id

  site_config {
    always_on                = false
    dotnet_framework_version = "v4.0"
    websockets_enabled       = true
    managed_pipeline_mode    = "Integrated"
  }

  app_settings = {
    "APPINSIGHTS_INSTRUMENTATIONKEY" = azurerm_application_insights.heroesappinsights.instrumentation_key
    "ApplicationInsights:InstrumentationKey" = azurerm_application_insights.heroesappinsights.instrumentation_key
  }
}

resource "azurerm_app_service_slot" "heroesapislot" {
  name                = "blue"
  app_service_name    = azurerm_app_service.heroesapi.name
  location            = azurerm_resource_group.zerorg.location
  resource_group_name = azurerm_resource_group.zerorg.name
  app_service_plan_id = azurerm_app_service_plan.zerosp.id

  site_config {
    always_on                = false
    dotnet_framework_version = "v4.0"
    websockets_enabled       = true
    managed_pipeline_mode    = "Integrated"
  }

  app_settings = {
    "APPINSIGHTS_INSTRUMENTATIONKEY" = azurerm_application_insights.heroesappinsights.instrumentation_key
    "ApplicationInsights:InstrumentationKey" = azurerm_application_insights.heroesappinsights.instrumentation_key
  }
}

## Front App Service
resource "azurerm_app_service" "heroesweb" {
  name                = var.heroesweb_appsvcname
  location            = azurerm_resource_group.zerorg.location
  resource_group_name = azurerm_resource_group.zerorg.name
  app_service_plan_id = azurerm_app_service_plan.zerosp.id

  site_config {
    always_on                = false
    dotnet_framework_version = "v4.0"
    websockets_enabled       = true
    managed_pipeline_mode    = "Integrated"
    default_documents         = ["index.html"]
  }

  app_settings = {
    "APPINSIGHTS_INSTRUMENTATIONKEY" = azurerm_application_insights.heroesappinsights.instrumentation_key
  }
}

resource "azurerm_app_service_slot" "heroeswebslot" {
  name                = "blue"
  app_service_name    = azurerm_app_service.heroesweb.name
  location            = azurerm_resource_group.zerorg.location
  resource_group_name = azurerm_resource_group.zerorg.name
  app_service_plan_id = azurerm_app_service_plan.zerosp.id

  site_config {
    always_on                = false
    dotnet_framework_version = "v4.0"
    websockets_enabled       = true
    managed_pipeline_mode    = "Integrated"
    default_documents         = ["index.html"]
  }
}

resource "azurerm_sql_server" "sqlsrv" {
  name                         = var.sql_server_name
  resource_group_name          = azurerm_resource_group.zerorg.name
  location                     = azurerm_resource_group.zerorg.location
  version                      = "12.0"
  administrator_login          = var.sql_server_login
  administrator_login_password = var.sql_server_pwd
}

resource "azurerm_sql_firewall_rule" "sqlsrvfirewall" {
  name                = "sqlfr1"
  resource_group_name = azurerm_resource_group.zerorg.name
  server_name         = azurerm_sql_server.sqlsrv.name
  start_ip_address    = "1.1.1.1"
  end_ip_address      = "255.255.255.255"
}

resource "azurerm_sql_database" "heroesdatabase" {
  name                             = var.database_name
  resource_group_name              = azurerm_resource_group.zerorg.name
  location                         = azurerm_resource_group.zerorg.location
  server_name                      = azurerm_sql_server.sqlsrv.name
  edition                          = "Standard"
  requested_service_objective_name = "S0"
}
