<template>
    <div>
        <Tablex ref="table" v-if="key" :key="key" module="Customers" :headers="headers">
            <template v-slot:add="">
                <v-menu :close-on-content-click="false">
                    <template v-slot:activator="{ props }">
                        <v-icon v-bind="props">mdi-plus</v-icon>
                    </template>
                    <v-card>
                        <v-card-text>
                            <Item @submit="refresh"> </Item>
                        </v-card-text>
                    </v-card>
                </v-menu>
            </template>
            <template v-slot:action="item">
                <v-menu :close-on-content-click="false">
                    <template v-slot:activator="{ props }">
                        <v-icon v-bind="props">mdi-pencil</v-icon>
                    </template>
                    <v-card>
                        <v-card-text>
                            <Item :value="item.item.raw" @submit="refresh"> </Item>
                        </v-card-text>
                    </v-card>
                </v-menu>
                <v-icon color="error" @click="remove(item.item.raw)">mdi-delete</v-icon>
            </template>

            <template v-slot:expanded-row="item">
                <tr>
                    <td colspan="7">
                        <Widget :value="item.item.raw" @submit="refresh"></Widget>
                    </td>
                </tr>
            </template>
        </Tablex>
    </div>
</template>
<script setup lang="ts">
import Item from '../item/i.vue';
import Widget from '../item/widget/i.vue';

import Tablex from '@/components/table/i.vue';

</script>

<script lang="ts">
import api from '@/store/api/i'

export default {
    data: () => ({
        headers: [
            { key: 'id', title: '#' },
            { key: 'name', title: 'Name & Surname' },
            { key: 'email', title: 'E-Mail' },
            { key: 'phone', title: 'Phone' },
            { key: 'bDay', title: 'Birthday' },
            { key: 'action', title: 'Actions' },

        ] as any,
        key: 1,
    }),


    methods: {
        async remove(m: any) {
            await api.delete('customers/' + m.id);
            (this.$refs as any).table.init();
            this.$emit('submit');
        },
        async refresh() {
            this.key = 0;
            this.$nextTick(() => this.key = new Date().getTime());
            setTimeout(() => {
                this.$nextTick(() => this.key = new Date().getTime());
            }, 1300)
        }
    }
}
</script>