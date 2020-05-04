variable "resource_group" {
  description = "Resource group name"
}
variable "location" {
  default = "westeurope"
  description = "Location for resources"
}
variable "heroesinsights" {
  description = "Application insights name"
}
variable "app_service_plan_name" {
  description = "App Service plan name"
}
variable "heroesapi_appsvcname" {
  description = "App Service name for api"
}
variable "heroesweb_appsvcname" {
  description = "App Service name for front"
}
variable "sql_server_login" {
  description = "Sql server administrator user"
}
variable "sql_server_pwd" {
  description = "Password for sql administrator user"
}
variable "sql_server_name" {
  description = "Azure Sql Server name"
}
variable "database_name" {
  description = "database name"
}