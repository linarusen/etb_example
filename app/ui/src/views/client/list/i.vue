<template>
    <div>
        <Tablex :key="key" module="Client" :headers="headers">
            <template v-slot:add="">
                <v-menu :close-on-content-click="false">
                    <template v-slot:activator="{ props }">
                        <v-icon v-bind="props">mdi-plus</v-icon>
                    </template>
                    <v-card>
                        <v-card-text>
                            <Item @submit="key = new Date().getTime()"> </Item>
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
                            <Item :value="item.item.raw" @submit="key = new Date().getTime()"> </Item>
                        </v-card-text>
                    </v-card>
                </v-menu>
                <v-icon color="error" @click="remove(item.item.raw)">mdi-delete</v-icon>
            </template>

            <template v-slot:expanded-row="item">
                <tr>
                    <td colspan="7">
                        <Widget :value="item.item.raw" @submit="key = new Date().getTime()"></Widget>
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
            { key: 'userAgent', title: 'User Agent' },
            { key: 'appCodeName', title: 'appCodeName' },
            { key: 'appName', title: 'appName' },
            { key: 'appVersion', title: 'appVersion' },
            { key: 'action', title: 'actions' },

        ] as any,
        key: 1,
    }),


    methods: {
        async remove(m: any) {
            await api.delete('customers', m);
            this.$emit('submit');
            this.key = 4;
        },
    }
}
</script>