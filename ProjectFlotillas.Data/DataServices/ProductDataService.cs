using ProjectFlotillas.Business.Entities;
using ProjectFlotillas.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFlotillas.Data.DataServices
{
    public class ProductDataService : IProductDataService
    {
        void IProductDataService.CreateProduct(Product product)
        {
            using (var connection = new SqlConnection(HelperConnection.Connection()))
            {
                connection.Open();
                var command = new SqlCommand("[dbo].[usp_RegisterProduct]", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@ProductName", product.ProductName));
                command.Parameters.Add(new SqlParameter("@QuantityPerUnit", product.QuantityPerUnit));
                command.Parameters.Add(new SqlParameter("@UnitPrice", product.UnitPrice));

                command.ExecuteNonQuery();
                //using (SqlDataReader reader = command.ExecuteReader())
                //{

                //    if (reader.Read())
                //    {
                //        cardHolderItem = new CardHolderDTO
                //        {

                //            Code = reader["CardHolderCode"].ToString(),
                //            Name = reader["CardHolderName"].ToString(),
                //            Surname = reader["CardHolderSurname"].ToString(),
                //            LastName = reader["CardHolderLastName"].ToString(),
                //            FullName = reader["CardHolderFullName"].ToString(),
                //            JobPosition = reader["JobPosition"].ToString(),
                //            PhoneNumber = reader["PhoneNumber"].ToString()

                //        };
                //    }
                //}
            }
        }

        Product IProductDataService.GetProduct(int productID)
        {
            using (var connection = new SqlConnection(HelperConnection.Connection()))
            {
                Product product = new Product();

                connection.Open();
                var command = new SqlCommand("[dbo].[usp_ProductById_GETI]", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@ProductId", productID));

                using (SqlDataReader reader = command.ExecuteReader())
                {                    
                    if (reader.Read())
                    {
                        product.ProductID = Convert.ToInt32(reader["ProductID"]);
                        product.ProductName = reader["ProductName"].ToString();
                        product.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                        product.QuantityPerUnit = reader["QuantityPerUnit"].ToString();
                    }
                }
                return product;
            }
        }

        List<Product> IProductDataService.GetProducts(int currentPageNumber, int pageSize, string sortExpression, string sortDirection, out int totalRows)
        {
            List<Product> list = new List<Product>();
            int i = 0;
            using (var connection = new SqlConnection(HelperConnection.Connection()))
            {                
                connection.Open();
                var command = new SqlCommand("[dbo].[usp_ProductALL_GETI]", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter("@PageSize", pageSize));
                command.Parameters.Add(new SqlParameter("@PageNumber", currentPageNumber-1));
                command.Parameters.Add(new SqlParameter("@sortExpression", sortExpression));
                command.Parameters.Add(new SqlParameter("@sortDirection", sortDirection));

                using (SqlDataReader reader = command.ExecuteReader())
                {                    
                    if (reader.HasRows)
                    {
                        
                        while (reader.Read())
                        {
                            list.Add(new Product
                            {
                                ProductID = Convert.ToInt32(reader["ProductID"]),
                                ProductName = reader["ProductName"].ToString(),
                                UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                                QuantityPerUnit = reader["QuantityPerUnit"].ToString()
                            }
                                );
                            i++;
                        }
                        
                    }
                }                
            }
            totalRows = i;
            return list;
        }

        void IProductDataService.UpdateProduct(Product product)
        {
            using (var connection = new SqlConnection(HelperConnection.Connection()))
            {
                connection.Open();
                var command = new SqlCommand("[dbo].[usp_UpdateProduct]", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("@ProductID", product.ProductID));
                command.Parameters.Add(new SqlParameter("@ProductName", product.ProductName));
                command.Parameters.Add(new SqlParameter("@QuantityPerUnit", product.QuantityPerUnit));
                command.Parameters.Add(new SqlParameter("@UnitPrice", product.UnitPrice));
                command.ExecuteNonQuery();                
            }
        }
    }
}
