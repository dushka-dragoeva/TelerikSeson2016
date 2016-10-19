<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >

  <xsl:template match="/">
    <html>
      <style>
        table {
        font-size: 18px;
        text-align: center;
        }

        table, th, tr, td {
        border: 3px solid purple;
        border-collapse: collapse;
        }

        th, tr, td {
        padding: 10px;
        }
      </style>

      <body>
        <h1>Students Information</h1>
        <table>
          <tr bgcolor="#FBEFFF" style="font-size:1.3em">
            <th>Student</th>
            <th>Gender</th>
            <th>Birth Date</th>
            <th>Phone</th>
            <th>E-mail</th>
            <th>Course</th>
            <th>Specialty</th>
            <th>Faculty #</th>
            <th>Exams</th>
          </tr>
          <xsl:for-each select="students/student">
            <tr>
              <td>
                <xsl:value-of select="name" />
              </td>
              <td>
                <xsl:value-of select="sex" />
              </td>
              <td>
                <xsl:value-of select="birthdate" />
              </td>
              <td>
                <xsl:value-of select="phone" />
              </td>
              <td>
                <xsl:value-of select="email" />
              </td>
              <td>
                <xsl:value-of select="course" />
              </td>
              <td>
                <xsl:value-of select="specialty" />
              </td>
              <td>
                <xsl:value-of select="facultynumber" />
              </td>
              <td  style="text-align:left">
                <xsl:for-each select="exams/exam" >
                  <div>
                    <strong>
                      <xsl:value-of select="name"/>
                    </strong> ,
                    tutor: <xsl:value-of select="tutor"/> ,
                    score: <xsl:value-of select="score"/>
                  </div>
                </xsl:for-each>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
