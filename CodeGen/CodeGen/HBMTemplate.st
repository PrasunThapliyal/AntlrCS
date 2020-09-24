\<?xml version="1.0" encoding="utf-8" ?>
\<hibernate-mapping xmlns = "urn:nhibernate-mapping-2.2"
   assembly = "<assemblyName>" namespace = "<namespace>">

  \<class name="<className>" table="<tableName>" lazy="true">
    \<id name = "Id" column="oid">
      \<generator class = "hilo"/>
    \</id>

    \<property name="<propertyName>" type="<csType>">
      \<column name="<columnName>" index="<indexName>"  sql-type="<sqlType>"/>
    \</property>

    \<bag name="<bagName>" lazy="true" cascade="all-delete-orphan" fetch="select">
      \<key column="<bagFKColumnName>">\</key>
      \<one-to-many class="<bagType>">\</one-to-many>
    \</bag>

  \</class>
\</hibernate-mapping>
