# CRUD com .NET, LINQ e SQLite

Este exercicio é um exemplo de implementação de um **CRUD** (Create, Read, Update, Delete) em **.NET**, utilizando **Entity Framework Core** com **LINQ assíncrono**, persistência em **SQLite** e visualização/interação via **Swagger UI**.

---

## Funcionalidades

1. **Create (Adicionar)**
   - Permite adicionar novos produtos ao banco de dados.
   - Utiliza `AddAsync` e `SaveChangesAsync` para operações não bloqueantes.

2. **Read (Consultar)**
   - Listar todos os produtos ou buscar por filtros específicos.
   - Métodos utilizados: `ToListAsync`, `FirstOrDefaultAsync`, `Where`, `AnyAsync`, `CountAsync`, `MaxAsync`.

3. **Update (Atualizar)**
   - Atualiza produtos existentes no banco.
   - Busca o registro pelo `id` ou outro campo único.
   - Modifica as propriedades necessárias e salva com `SaveChangesAsync`.

4. **Delete (Remover)**
   - Remove produtos do banco de dados.
   - Utiliza `_context.Remove()` seguido de `SaveChangesAsync`.


---

## Tecnologias Utilizadas

- **.NET 7 / ASP.NET Core**
- **Entity Framework Core**
- **SQLite** (banco local leve)
- **LINQ Assíncrono**
- **Swagger UI** (para testar endpoints de forma visual e interativa)
- **C# 11** (programação orientada a objetos e async/await)

---

## Exemplos de Uso

### Adicionar Produto
```csharp
await _context.Produtos.AddAsync(novoProduto);
await _context.SaveChangesAsync();
```
## Images

<img width="1861" height="627" alt="image" src="https://github.com/user-attachments/assets/fef20c0a-9766-41a5-81f2-17e4d0b46886" />
<img width="1760" height="833" alt="image" src="https://github.com/user-attachments/assets/e1f05440-7e01-42f5-b9b2-3b365b8f1cf7" />

###  Ativando o DB, consultando tabelas disponiveis e consultando o banco atravez de queries retornando total de produtos

<img width="753" height="283" alt="image" src="https://github.com/user-attachments/assets/8144c47a-dd8c-41c4-8bd0-24719a1fe0f3" />





