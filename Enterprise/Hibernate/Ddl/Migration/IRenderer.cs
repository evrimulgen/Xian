using System;
using System.Collections.Generic;
using System.Text;

namespace ClearCanvas.Enterprise.Hibernate.Ddl.Migration
{
	interface IRenderer
	{
        IEnumerable<Change> PreFilter(IEnumerable<Change> changes);

		Statement[] Render(AddTableChange change);
		Statement[] Render(DropTableChange change);
		Statement[] Render(AddColumnChange change);
		Statement[] Render(DropColumnChange change);
		Statement[] Render(AddIndexChange change);
		Statement[] Render(DropIndexChange change);
		Statement[] Render(AddPrimaryKeyChange change);
		Statement[] Render(DropPrimaryKeyChange change);
		Statement[] Render(AddForeignKeyChange change);
		Statement[] Render(DropForeignKeyChange change);
		Statement[] Render(AddUniqueConstraintChange change);
		Statement[] Render(DropUniqueConstraintChange change);
		Statement[] Render(ModifyColumnChange change);
		Statement[] Render(AddEnumValueChange change);
		Statement[] Render(DropEnumValueChange change);
	}
}