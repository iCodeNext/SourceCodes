﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#pragma warning disable 219, 612, 618
#nullable disable

namespace EFPerformance.CompiledModels
{
    public partial class AppDbContextModel
    {
        partial void Initialize()
        {
            var post = PostEntityType.Create(this);
            var tag = TagEntityType.Create(this);
            var user = UserEntityType.Create(this);

            PostEntityType.CreateForeignKey1(post, user);
            TagEntityType.CreateForeignKey1(tag, post);

            PostEntityType.CreateAnnotations(post);
            TagEntityType.CreateAnnotations(tag);
            UserEntityType.CreateAnnotations(user);

            AddAnnotation("ProductVersion", "8.0.6");
            AddAnnotation("Relational:MaxIdentifierLength", 128);
            AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            AddRuntimeAnnotation("Relational:RelationalModel", CreateRelationalModel());
        }

        private IRelationalModel CreateRelationalModel()
        {
            var relationalModel = new RelationalModel(this);

            var post = FindEntityType("EFPerformance.Post")!;

            var defaultTableMappings = new List<TableMappingBase<ColumnMappingBase>>();
            post.SetRuntimeAnnotation("Relational:DefaultMappings", defaultTableMappings);
            var eFPerformancePostTableBase = new TableBase("EFPerformance.Post", null, relationalModel);
            var descriptionColumnBase = new ColumnBase<ColumnMappingBase>("Description", "nvarchar(max)", eFPerformancePostTableBase)
            {
                IsNullable = true
            };
            eFPerformancePostTableBase.Columns.Add("Description", descriptionColumnBase);
            var idColumnBase = new ColumnBase<ColumnMappingBase>("Id", "int", eFPerformancePostTableBase);
            eFPerformancePostTableBase.Columns.Add("Id", idColumnBase);
            var titleColumnBase = new ColumnBase<ColumnMappingBase>("Title", "nvarchar(max)", eFPerformancePostTableBase)
            {
                IsNullable = true
            };
            eFPerformancePostTableBase.Columns.Add("Title", titleColumnBase);
            var userIdColumnBase = new ColumnBase<ColumnMappingBase>("UserId", "int", eFPerformancePostTableBase);
            eFPerformancePostTableBase.Columns.Add("UserId", userIdColumnBase);
            relationalModel.DefaultTables.Add("EFPerformance.Post", eFPerformancePostTableBase);
            var eFPerformancePostMappingBase = new TableMappingBase<ColumnMappingBase>(post, eFPerformancePostTableBase, true);
            eFPerformancePostTableBase.AddTypeMapping(eFPerformancePostMappingBase, false);
            defaultTableMappings.Add(eFPerformancePostMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)idColumnBase, post.FindProperty("Id")!, eFPerformancePostMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)descriptionColumnBase, post.FindProperty("Description")!, eFPerformancePostMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)titleColumnBase, post.FindProperty("Title")!, eFPerformancePostMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)userIdColumnBase, post.FindProperty("UserId")!, eFPerformancePostMappingBase);

            var tableMappings = new List<TableMapping>();
            post.SetRuntimeAnnotation("Relational:TableMappings", tableMappings);
            var postsTable = new Table("Posts", null, relationalModel);
            var idColumn = new Column("Id", "int", postsTable);
            postsTable.Columns.Add("Id", idColumn);
            var descriptionColumn = new Column("Description", "nvarchar(max)", postsTable)
            {
                IsNullable = true
            };
            postsTable.Columns.Add("Description", descriptionColumn);
            var titleColumn = new Column("Title", "nvarchar(max)", postsTable)
            {
                IsNullable = true
            };
            postsTable.Columns.Add("Title", titleColumn);
            var userIdColumn = new Column("UserId", "int", postsTable);
            postsTable.Columns.Add("UserId", userIdColumn);
            var pK_Posts = new UniqueConstraint("PK_Posts", postsTable, new[] { idColumn });
            postsTable.PrimaryKey = pK_Posts;
            var pK_PostsUc = RelationalModel.GetKey(this,
                "EFPerformance.Post",
                new[] { "Id" });
            pK_Posts.MappedKeys.Add(pK_PostsUc);
            RelationalModel.GetOrCreateUniqueConstraints(pK_PostsUc).Add(pK_Posts);
            postsTable.UniqueConstraints.Add("PK_Posts", pK_Posts);
            var iX_Posts_UserId = new TableIndex(
            "IX_Posts_UserId", postsTable, new[] { userIdColumn }, false);
            var iX_Posts_UserIdIx = RelationalModel.GetIndex(this,
                "EFPerformance.Post",
                new[] { "UserId" });
            iX_Posts_UserId.MappedIndexes.Add(iX_Posts_UserIdIx);
            RelationalModel.GetOrCreateTableIndexes(iX_Posts_UserIdIx).Add(iX_Posts_UserId);
            postsTable.Indexes.Add("IX_Posts_UserId", iX_Posts_UserId);
            relationalModel.Tables.Add(("Posts", null), postsTable);
            var postsTableMapping = new TableMapping(post, postsTable, true);
            postsTable.AddTypeMapping(postsTableMapping, false);
            tableMappings.Add(postsTableMapping);
            RelationalModel.CreateColumnMapping(idColumn, post.FindProperty("Id")!, postsTableMapping);
            RelationalModel.CreateColumnMapping(descriptionColumn, post.FindProperty("Description")!, postsTableMapping);
            RelationalModel.CreateColumnMapping(titleColumn, post.FindProperty("Title")!, postsTableMapping);
            RelationalModel.CreateColumnMapping(userIdColumn, post.FindProperty("UserId")!, postsTableMapping);

            var tag = FindEntityType("EFPerformance.Tag")!;

            var defaultTableMappings0 = new List<TableMappingBase<ColumnMappingBase>>();
            tag.SetRuntimeAnnotation("Relational:DefaultMappings", defaultTableMappings0);
            var eFPerformanceTagTableBase = new TableBase("EFPerformance.Tag", null, relationalModel);
            var idColumnBase0 = new ColumnBase<ColumnMappingBase>("Id", "int", eFPerformanceTagTableBase);
            eFPerformanceTagTableBase.Columns.Add("Id", idColumnBase0);
            var postIdColumnBase = new ColumnBase<ColumnMappingBase>("PostId", "int", eFPerformanceTagTableBase);
            eFPerformanceTagTableBase.Columns.Add("PostId", postIdColumnBase);
            var titleColumnBase0 = new ColumnBase<ColumnMappingBase>("Title", "nvarchar(max)", eFPerformanceTagTableBase)
            {
                IsNullable = true
            };
            eFPerformanceTagTableBase.Columns.Add("Title", titleColumnBase0);
            relationalModel.DefaultTables.Add("EFPerformance.Tag", eFPerformanceTagTableBase);
            var eFPerformanceTagMappingBase = new TableMappingBase<ColumnMappingBase>(tag, eFPerformanceTagTableBase, true);
            eFPerformanceTagTableBase.AddTypeMapping(eFPerformanceTagMappingBase, false);
            defaultTableMappings0.Add(eFPerformanceTagMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)idColumnBase0, tag.FindProperty("Id")!, eFPerformanceTagMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)postIdColumnBase, tag.FindProperty("PostId")!, eFPerformanceTagMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)titleColumnBase0, tag.FindProperty("Title")!, eFPerformanceTagMappingBase);

            var tableMappings0 = new List<TableMapping>();
            tag.SetRuntimeAnnotation("Relational:TableMappings", tableMappings0);
            var tagsTable = new Table("Tags", null, relationalModel);
            var idColumn0 = new Column("Id", "int", tagsTable);
            tagsTable.Columns.Add("Id", idColumn0);
            var postIdColumn = new Column("PostId", "int", tagsTable);
            tagsTable.Columns.Add("PostId", postIdColumn);
            var titleColumn0 = new Column("Title", "nvarchar(max)", tagsTable)
            {
                IsNullable = true
            };
            tagsTable.Columns.Add("Title", titleColumn0);
            var pK_Tags = new UniqueConstraint("PK_Tags", tagsTable, new[] { idColumn0 });
            tagsTable.PrimaryKey = pK_Tags;
            var pK_TagsUc = RelationalModel.GetKey(this,
                "EFPerformance.Tag",
                new[] { "Id" });
            pK_Tags.MappedKeys.Add(pK_TagsUc);
            RelationalModel.GetOrCreateUniqueConstraints(pK_TagsUc).Add(pK_Tags);
            tagsTable.UniqueConstraints.Add("PK_Tags", pK_Tags);
            var iX_Tags_PostId = new TableIndex(
            "IX_Tags_PostId", tagsTable, new[] { postIdColumn }, false);
            var iX_Tags_PostIdIx = RelationalModel.GetIndex(this,
                "EFPerformance.Tag",
                new[] { "PostId" });
            iX_Tags_PostId.MappedIndexes.Add(iX_Tags_PostIdIx);
            RelationalModel.GetOrCreateTableIndexes(iX_Tags_PostIdIx).Add(iX_Tags_PostId);
            tagsTable.Indexes.Add("IX_Tags_PostId", iX_Tags_PostId);
            relationalModel.Tables.Add(("Tags", null), tagsTable);
            var tagsTableMapping = new TableMapping(tag, tagsTable, true);
            tagsTable.AddTypeMapping(tagsTableMapping, false);
            tableMappings0.Add(tagsTableMapping);
            RelationalModel.CreateColumnMapping(idColumn0, tag.FindProperty("Id")!, tagsTableMapping);
            RelationalModel.CreateColumnMapping(postIdColumn, tag.FindProperty("PostId")!, tagsTableMapping);
            RelationalModel.CreateColumnMapping(titleColumn0, tag.FindProperty("Title")!, tagsTableMapping);

            var user = FindEntityType("EFPerformance.User")!;

            var defaultTableMappings1 = new List<TableMappingBase<ColumnMappingBase>>();
            user.SetRuntimeAnnotation("Relational:DefaultMappings", defaultTableMappings1);
            var eFPerformanceUserTableBase = new TableBase("EFPerformance.User", null, relationalModel);
            var idColumnBase1 = new ColumnBase<ColumnMappingBase>("Id", "int", eFPerformanceUserTableBase);
            eFPerformanceUserTableBase.Columns.Add("Id", idColumnBase1);
            var nameColumnBase = new ColumnBase<ColumnMappingBase>("Name", "nvarchar(max)", eFPerformanceUserTableBase)
            {
                IsNullable = true
            };
            eFPerformanceUserTableBase.Columns.Add("Name", nameColumnBase);
            relationalModel.DefaultTables.Add("EFPerformance.User", eFPerformanceUserTableBase);
            var eFPerformanceUserMappingBase = new TableMappingBase<ColumnMappingBase>(user, eFPerformanceUserTableBase, true);
            eFPerformanceUserTableBase.AddTypeMapping(eFPerformanceUserMappingBase, false);
            defaultTableMappings1.Add(eFPerformanceUserMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)idColumnBase1, user.FindProperty("Id")!, eFPerformanceUserMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)nameColumnBase, user.FindProperty("Name")!, eFPerformanceUserMappingBase);

            var tableMappings1 = new List<TableMapping>();
            user.SetRuntimeAnnotation("Relational:TableMappings", tableMappings1);
            var usersTable = new Table("Users", null, relationalModel);
            var idColumn1 = new Column("Id", "int", usersTable);
            usersTable.Columns.Add("Id", idColumn1);
            var nameColumn = new Column("Name", "nvarchar(max)", usersTable)
            {
                IsNullable = true
            };
            usersTable.Columns.Add("Name", nameColumn);
            var pK_Users = new UniqueConstraint("PK_Users", usersTable, new[] { idColumn1 });
            usersTable.PrimaryKey = pK_Users;
            var pK_UsersUc = RelationalModel.GetKey(this,
                "EFPerformance.User",
                new[] { "Id" });
            pK_Users.MappedKeys.Add(pK_UsersUc);
            RelationalModel.GetOrCreateUniqueConstraints(pK_UsersUc).Add(pK_Users);
            usersTable.UniqueConstraints.Add("PK_Users", pK_Users);
            relationalModel.Tables.Add(("Users", null), usersTable);
            var usersTableMapping = new TableMapping(user, usersTable, true);
            usersTable.AddTypeMapping(usersTableMapping, false);
            tableMappings1.Add(usersTableMapping);
            RelationalModel.CreateColumnMapping(idColumn1, user.FindProperty("Id")!, usersTableMapping);
            RelationalModel.CreateColumnMapping(nameColumn, user.FindProperty("Name")!, usersTableMapping);
            var fK_Posts_Users_UserId = new ForeignKeyConstraint(
                "FK_Posts_Users_UserId", postsTable, usersTable,
                new[] { userIdColumn },
                usersTable.FindUniqueConstraint("PK_Users")!, ReferentialAction.Cascade);
            var fK_Posts_Users_UserIdFk = RelationalModel.GetForeignKey(this,
                "EFPerformance.Post",
                new[] { "UserId" },
                "EFPerformance.User",
                new[] { "Id" });
            fK_Posts_Users_UserId.MappedForeignKeys.Add(fK_Posts_Users_UserIdFk);
            RelationalModel.GetOrCreateForeignKeyConstraints(fK_Posts_Users_UserIdFk).Add(fK_Posts_Users_UserId);
            postsTable.ForeignKeyConstraints.Add(fK_Posts_Users_UserId);
            usersTable.ReferencingForeignKeyConstraints.Add(fK_Posts_Users_UserId);
            var fK_Tags_Posts_PostId = new ForeignKeyConstraint(
                "FK_Tags_Posts_PostId", tagsTable, postsTable,
                new[] { postIdColumn },
                postsTable.FindUniqueConstraint("PK_Posts")!, ReferentialAction.Cascade);
            var fK_Tags_Posts_PostIdFk = RelationalModel.GetForeignKey(this,
                "EFPerformance.Tag",
                new[] { "PostId" },
                "EFPerformance.Post",
                new[] { "Id" });
            fK_Tags_Posts_PostId.MappedForeignKeys.Add(fK_Tags_Posts_PostIdFk);
            RelationalModel.GetOrCreateForeignKeyConstraints(fK_Tags_Posts_PostIdFk).Add(fK_Tags_Posts_PostId);
            tagsTable.ForeignKeyConstraints.Add(fK_Tags_Posts_PostId);
            postsTable.ReferencingForeignKeyConstraints.Add(fK_Tags_Posts_PostId);
            return relationalModel.MakeReadOnly();
        }
    }
}
